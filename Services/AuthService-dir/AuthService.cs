
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Twitter.DTOs;
using Twitter.Model;
using Twitter.Services.MailService_dir;
using Twitter.Unit_of_work;

namespace Twitter.Services.AuthService_dir
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IMailService mailService;
        private readonly IUnitOfWork unitOfWork;

        public AuthService(UserManager<ApplicationUser> userManager,
                             IConfiguration configuration,
                             IMailService mailService,
                             IUnitOfWork unitOfWork)
                             
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.mailService = mailService;
            this.unitOfWork = unitOfWork;
        }
        
        // 1 - Register And Login
        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var checkExistedUserWithEmail = await userManager.FindByEmailAsync(registerDto.Email);
        
            if (checkExistedUserWithEmail != null)
                return new AuthResponseDto { Message = "This email already exists" };
        
            ApplicationUser appUser = new ApplicationUser();
        
            appUser.Email = registerDto.Email;
            appUser.FirstName = registerDto.FirstName;
            appUser.LastName = registerDto.LastName;
            appUser.UserName = registerDto.Email;
            appUser.EmailConfirmed = false;
        
        
            var IdentRes = await userManager.CreateAsync(appUser, registerDto.Password);
        
            if (!IdentRes.Succeeded)
            {
                string errors = "";
        
                foreach (var error in IdentRes.Errors)
                {
                    errors += (error.Description + ", ");
                }
        
                return new AuthResponseDto { Message = errors };
            }
        
        
        
            await userManager.AddToRoleAsync(appUser, "User");
        
            TokenResponseDto tokens = await GenerateTokensAsync(appUser.Id);
        
        
        
            AuthResponseDto authDto = new AuthResponseDto
            {
                IsAuthenticated = true,
                Token = tokens.AccessToken,
                RefreshToken = tokens.RefreshToken,
                Email = registerDto.Email,
                ExpiresOn = DateTime.Now.AddMinutes(15),
                Roles = new List<string>() { "User" }
        
            };
        
            await SendConfirmationCode(appUser.Email);
        
        
            return authDto;
        
        }
        
        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var isExistedUserWithEmail = await userManager.FindByEmailAsync(loginDto.Email);
        
            if (isExistedUserWithEmail == null)
                return new AuthResponseDto { Message = "Invalid Email or Password" };
        
            var isPasswordMatchingWithEmail = await userManager
                 .CheckPasswordAsync(isExistedUserWithEmail, loginDto.Password);
        
            if (!isPasswordMatchingWithEmail)
                return new AuthResponseDto { Message = "Invalid Email or Password" };
        
        
        
        
            TokenResponseDto tokens = await GenerateTokensAsync(isExistedUserWithEmail.Id);
        
            var roles = await userManager.GetRolesAsync(isExistedUserWithEmail);
        
            AuthResponseDto authDto = new AuthResponseDto
            {
        
                Email = loginDto.Email,
                IsAuthenticated = true,
                Token = tokens.AccessToken,
                RefreshToken = tokens.RefreshToken,
                ExpiresOn = DateTime.Now.AddMinutes(15),
                Roles = roles.ToList()
        
            };
        
        
            return authDto;
        
        }
        
        
        
        // 2 - Email Confirmation
        
        public async Task<bool> SendConfirmationCode(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
        
            if (user == null) return false;
        
            var ConfirmationCode = await userManager.GenerateEmailConfirmationTokenAsync(user);


            bool sent = await mailService.SendMailAsync(email, "Confirmation code", $"<h2>{ConfirmationCode}</h2>");
        
            return sent;
        
        
        }
        
        public async Task<bool> ConfirmEmailAsync(string email, string code)
        {
            var user = await userManager.FindByEmailAsync(email);
        
            if (user == null || code == null) return false;
        
            var res = await userManager.ConfirmEmailAsync(user, code);
        
            if (res.Succeeded) return true;
        
            return false;
        
        }
        
        private async Task<bool> IsEmailConfirmed(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
        
            if (user == null) return false;
        
            bool isConfirmed = await userManager.IsEmailConfirmedAsync(user);
        
            return isConfirmed;
        }


        // 4 - Tokens Generation   
        public async Task<TokenResponseDto> GenerateTokensAsync(string userId)
        {
            Console.WriteLine(userId + "haa");

            var accessToken = await GenerateAccessTokenAsync(userId);
            var refreshToken = await GenerateRefreshTokenAsync(userId);


            var tokenResponse = new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };

            return tokenResponse;
        }

        private async Task<string> GenerateAccessTokenAsync(string userId)
        {


            ApplicationUser appUser = await userManager.FindByIdAsync(userId.ToString());

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var roles = await userManager.GetRolesAsync(appUser);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }



            SecurityKey secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(double.Parse(configuration["JWT:ExpiryDuration"])),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private async Task<RefreshToken> GenerateRefreshTokenAsync(string userId)
        {
            RefreshToken refreshToken = new RefreshToken();

            refreshToken.CreatedAt = DateTime.Now;
            refreshToken.isRevoked = false;

            refreshToken.ExpiryDate = DateTime.Now.AddDays(30);
            refreshToken.AppUserId = userId;

            refreshToken.Token = Guid.NewGuid().ToString() + "_" + Guid.NewGuid().ToString();

            await unitOfWork.RefreshTokenRepo.InsertAsync(refreshToken);

            return refreshToken;
        }

        public async Task<TokenResponseDto> RefreshTokenAsync(string refreshToken)
        {

            var refToken = await
                unitOfWork.RefreshTokenRepo.GetValidRefreshTokenAsync(refreshToken);

            if (refToken == null)
                return new TokenResponseDto
                {
                    Successed = false
                };

            if (refToken.ExpiryDate > DateTime.Now.AddDays(1))
            {
                var accessTok = await GenerateAccessTokenAsync(refToken.AppUserId);
                refToken.ExpiryDate = DateTime.Now.AddDays(15);

                return new TokenResponseDto
                {
                    AccessToken = accessTok,
                    RefreshToken = refToken.Token
                };
            }

            refToken.isRevoked = true;

            await unitOfWork.CompleteAsync();

            return await GenerateTokensAsync(refToken.AppUserId);

        }

        // 3 - Forget And Reset Password
        public async Task<bool> ForgetPasswordAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null) return false;

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            bool check = await mailService.SendMailAsync(email, "Reset Password Token", token);

            return check;
        }


        // - Needs to be Refactored -_-
        public async Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await userManager.FindByEmailAsync(resetPasswordDto.email);

            if (user == null) return false;

            var res = await userManager.ResetPasswordAsync(user, resetPasswordDto.token,
                                                                 resetPasswordDto.Password);

            return res.Succeeded;
        }



    }
}
