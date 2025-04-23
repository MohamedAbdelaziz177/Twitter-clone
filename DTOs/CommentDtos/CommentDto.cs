using Twitter.Model;

namespace Twitter.DTOs.CommentDtos
{
    public class CommentDto
    {
       
        public int Id { get; set; } // in case you need to edit it
        public string Content { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string AuthorId { get; set; } = string.Empty; // to click on the name and get Profile

        public int PostId { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
