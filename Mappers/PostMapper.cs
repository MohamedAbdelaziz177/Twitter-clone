using Twitter.DTOs.AuthDtos;
using Twitter.DTOs.PostDtos;
using Twitter.Model;

namespace Twitter.Mappers
{
    public static class PostMapper
    {

        public static PostDto toDto(this Post post)
        {
            PostDto dto = new();

            dto.Id = post.Id;
            dto.AuthorId = post.ApplicationUser.Id;
            dto.Author = post.ApplicationUser.FirstName + " " + post.ApplicationUser.LastName;
            dto.CreatedAt = post.CreatedAt;
            dto.ImgUrl = post.ImgUrl;
            dto.CommentsCount = post.RepliesCount;
            dto.LikesCount = post.LikesCount;
            dto.BookmarksCount = post.BookmarksCount;

            foreach(Comment comment in post.comments)
                dto.Comments.Add(comment.toDto());

            return dto;
        }

        public static Post fromDto(this Post post ,CreateUpdatePostDto postDto) 
        {
           

            post.content = postDto.Description;
            post.ImgUrl = "";

            return post;
        }
    }
}
