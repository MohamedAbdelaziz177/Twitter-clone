using System.ComponentModel.DataAnnotations;

namespace Twitter.DTOs.CommentDtos
{
    public class CreateUpdateCommentDto
    {
        [Required]
        public string content { get; set; } = string.Empty;
    }
}
