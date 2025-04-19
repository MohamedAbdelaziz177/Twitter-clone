namespace Twitter.DTOs.AuthDtos
{
    public class TokenResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

        public bool Successed { get; set; } = true;
    }
}
