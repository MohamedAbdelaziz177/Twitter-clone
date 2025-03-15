using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Twitter.DTOs;
using Twitter.Services.AuthService_dir;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            AuthResponseDto authResponse = await authService.RegisterAsync(registerDto);

            if (!authResponse.IsAuthenticated)
                return BadRequest(authResponse.Message);

            Response.Cookies.Append("refreshtoken", authResponse.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            });
            

            return Ok(authResponse);

        }


        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           

            AuthResponseDto authResponse = await authService.LoginAsync(loginDto);

            if(!authResponse.IsAuthenticated)
                return BadRequest(authResponse.Message);


            Response.Cookies.Append("refreshtoken", authResponse.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            });

            return Ok(authResponse);
        }

        [HttpGet("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromQuery] string email)
        {
            bool succ = await authService.ForgetPasswordAsync(email);

            return Ok("Check ur email");
        }


        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool succ = await authService.ResetPasswordAsync(resetPasswordDto);

            if (!succ)
                return BadRequest("Password not reset");
            

            return Ok("Password reset successfully");
        }

        [Authorize]
        [HttpGet("RequestEmailConfirmation")]
        public async Task<IActionResult> RequestEmailConfirmation()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            bool succ = await authService.SendConfirmationCode(email);

            if (!succ)
                return BadRequest("Confirmation Code not sent");

            return Ok("Confirmation code sent successfully");
        }

        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto confirmEmailDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool succ = await authService.ConfirmEmailAsync(confirmEmailDto.Email, confirmEmailDto.token);

            if (!succ)
                return BadRequest("Try Again");

            return Ok("Email Confirmed successfully");
        }

      //[Authorize]
        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refToken = Request.Cookies["refreshtoken"];

            if (refToken == null)
                return BadRequest("No Refresh Tokens available");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            TokenResponseDto tokenResponse = await authService.RefreshTokenAsync(refToken);

            if (!tokenResponse.Successed)
                return BadRequest();


            if(tokenResponse.RefreshToken != refToken)
            {
                Response.Cookies.Append("refreshtoken", tokenResponse.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(15)
                });
            }

            return Ok(tokenResponse);

        }


    }
}
