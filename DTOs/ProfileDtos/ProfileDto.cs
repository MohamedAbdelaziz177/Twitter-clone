using Twitter.DTOs.PostDtos;

namespace Twitter.DTOs.ProfileDtos
{
    public class ProfileDto
    {
        public string Name { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public List<PostDto> PostDtos { get; set; } = new();
    }
}
