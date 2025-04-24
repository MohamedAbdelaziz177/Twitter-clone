using Twitter.DTOs.CommentDtos;
using Twitter.Model;

namespace Twitter.Mappers
{
    public static class CommentMapper
    {

        public static CommentDto toDto(this Comment comment)
        {
            CommentDto dto = new CommentDto();

            dto.Content = comment.Content;
            dto.CreatedAt = comment.CreatedAt;
            dto.Author = comment.ApplicationUser.FirstName + " " + comment.ApplicationUser.LastName;
            dto.AuthorId = comment.UserId;
            dto.PostId = comment.PostId;

            return dto;  
        }

        public static Comment fromDto(this CreateUpdateCommentDto dto)
        {
            Comment comment = new Comment();
            comment.Content = dto.content;

            return comment;
        }
    }
}
