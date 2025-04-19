using Twitter.DTOs.CommentDtos;
using Twitter.Model;

namespace Twitter.DTOs.PostDtos
{
    public class PostDto
    {
        

        public string Description { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }

        public string ImgUrl { get; set; }

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }

        public int BookmarksCount { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<CommentDto> comments { get; set; }
    }
}
