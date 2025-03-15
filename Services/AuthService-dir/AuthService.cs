using MailKit;
using Microsoft.AspNetCore.Identity;
using Twitter.DTOs;
using Twitter.Model;

namespace Twitter.Services.AuthService_dir
{
    public class AuthService /*: IAuthService*/
    {
      // private readonly UserManager<ApplicationUser> userManager;
      // private readonly IConfiguration configuration;
      // private readonly IMailService mailService;
      // 
      //
      //
      // public AuthService(UserManager<ApplicationUser> userManager,
      //                      IConfiguration configuration,
      //                      IMailService mailService)
      //                      
      // {
      //     this.userManager = userManager;
      //     this.configuration = configuration;
      //     this.mailService = mailService;
      //    
      // }
      //
      // // 1 - Register And Login
      // public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
      // {
      //     var checkExistedUserWithEmail = await userManager.FindByEmailAsync(registerDto.Email);
      //
      //     if (checkExistedUserWithEmail != null)
      //         return new AuthResponseDto { Message = "This email already exists" };
      //
      //     ApplicationUser appUser = new ApplicationUser();
      //
      //     appUser.Email = registerDto.Email;
      //     appUser.FirstName = registerDto.FirstName;
      //     appUser.LastName = registerDto.LastName;
      //     appUser.UserName = registerDto.Email;
      //     appUser.EmailConfirmed = false;
      //
      //
      //     var IdentRes = await userManager.CreateAsync(appUser, registerDto.Password);
      //
      //     if (!IdentRes.Succeeded)
      //     {
      //         string errors = "";
      //
      //         foreach (var error in IdentRes.Errors)
      //         {
      //             errors += (error.Description + ", ");
      //         }
      //
      //         return new AuthResponseDto { Message = errors };
      //     }
      //
      //
      //
      //     await userManager.AddToRoleAsync(appUser, "User");
      //
      //     TokenResponseDto tokens = await GenerateTokensAsync(appUser.Id);
      //
      //
      //
      //     AuthResponseDto authDto = new AuthResponseDto
      //     {
      //         IsAuthenticated = true,
      //         Token = tokens.AccessToken,
      //         RefreshToken = tokens.RefreshToken,
      //         Email = registerDto.Email,
      //         ExpiresOn = DateTime.Now.AddMinutes(15),
      //         Roles = new List<string>() { "User" }
      //
      //     };
      //
      //     await SendConfirmationCode(appUser.Email);
      //
      //
      //     return authDto;
      //
      // }
      //
      // public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
      // {
      //     var isExistedUserWithEmail = await userManager.FindByEmailAsync(loginDto.Email);
      //
      //     if (isExistedUserWithEmail == null)
      //         return new AuthResponseDto { Message = "Invalid Email or Password" };
      //
      //     var isPasswordMatchingWithEmail = await userManager
      //          .CheckPasswordAsync(isExistedUserWithEmail, loginDto.Password);
      //
      //     if (!isPasswordMatchingWithEmail)
      //         return new AuthResponseDto { Message = "Invalid Email or Password" };
      //
      //
      //
      //
      //     TokenResponseDto tokens = await GenerateTokensAsync(isExistedUserWithEmail.Id);
      //
      //     var roles = await userManager.GetRolesAsync(isExistedUserWithEmail);
      //
      //     AuthResponseDto authDto = new AuthResponseDto
      //     {
      //
      //         Email = loginDto.Email,
      //         IsAuthenticated = true,
      //         Token = tokens.AccessToken,
      //         RefreshToken = tokens.RefreshToken,
      //         ExpiresOn = DateTime.Now.AddMinutes(15),
      //         Roles = roles.ToList()
      //
      //     };
      //
      //
      //     return authDto;
      //
      // }
      //
      //
      //
      // // 2 - Email Confirmation
      //
      // public async Task<bool> SendConfirmationCode(string email)
      // {
      //     var user = await userManager.FindByEmailAsync(email);
      //
      //     if (user == null) return false;
      //
      //     var ConfirmationCode = await userManager.GenerateEmailConfirmationTokenAsync(user);
      //
      //     bool sent = await mailService
      //         .SendMailAsync(email, "Email Verfication", $"<h2>{ConfirmationCode}</h2>");
      //
      //     return sent;
      //
      //
      // }
      //
      // public async Task<bool> ConfirmEmailAsync(string email, string code)
      // {
      //     var user = await userManager.FindByEmailAsync(email);
      //
      //     if (user == null || code == null) return false;
      //
      //     var res = await userManager.ConfirmEmailAsync(user, code);
      //
      //     if (res.Succeeded) return true;
      //
      //     return false;
      //
      // }
      //
      // private async Task<bool> IsEmailConfirmed(string email)
      // {
      //     var user = await userManager.FindByEmailAsync(email);
      //
      //     if (user == null) return false;
      //
      //     bool isConfirmed = await userManager.IsEmailConfirmedAsync(user);
      //
      //     return isConfirmed;
      // }

    }
}
