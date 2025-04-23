namespace Twitter.DTOs.ProfileDtos
{
    public class UpdateProfileDto
    {
        public string Name { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public IFormFile Img { get; set; } = default!;
    }
}
