using System.ComponentModel.DataAnnotations;

namespace Twitter.DTOs.AuthDtos
{
    public class ResetPasswordDto
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public string token { get; set; } = string.Empty;
    }
}
