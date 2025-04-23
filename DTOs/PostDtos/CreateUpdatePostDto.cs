namespace Twitter.DTOs.PostDtos
{
    public class CreateUpdatePostDto
    {
        public string Description { get; set; } = "";
        public IFormFile Img { get; set; } = default!;
    }
}
