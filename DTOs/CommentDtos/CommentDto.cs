using Twitter.Model;

namespace Twitter.DTOs.CommentDtos
{
    public class CommentDto
    {
        public CommentDto(Comment comment) 
        {
            this.Content = comment.Content;
            this.AuthorId = comment.UserId;
        }
        public string Content { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }
    }
}
