namespace Twitter.DTOs.AuthDtos
{
    public class ConfirmEmailDto
    {
        public string Email { get; set; } = string.Empty;

        public string token { get; set; } = string.Empty;
    }
}
