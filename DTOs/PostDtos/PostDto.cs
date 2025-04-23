using Twitter.DTOs.CommentDtos;
using Twitter.Model;

namespace Twitter.DTOs.PostDtos
{
    public class PostDto
    {
        
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string AuthorId { get; set; } = string.Empty;// to click on the name and get Profile

        public string ImgUrl { get; set; } = string.Empty;

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }

        public int BookmarksCount { get; set; }

        public bool IsLikedByCurrentUser { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CommentDto> Comments { get; set; } = default!;
    }
}
