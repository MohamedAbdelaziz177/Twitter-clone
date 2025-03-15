using Twitter.DTOs;

namespace Twitter.Services.AuthService_dir
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);

        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);

        Task<TokenResponseDto> RefreshTokenAsync(string refreshToken, int userId);

        Task<bool> ConfirmEmailAsync(string email, string code);

        Task<bool> SendConfirmationCode(string email);

        Task<bool> ForgetPasswordAsync(string email);

        Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
