using Twitter.DTOs.CommentDtos;

namespace Twitter.Services.CommentService_dir
{
    public interface ICommentService
    {
        Task<CommentDto> GetCommentById(int id);

        Task<List<CommentDto>> GetCommentsByPostId(int postId);

        Task<List<CommentDto>> GetCommentsByUserId(string userId);

        Task<CommentDto> AddNewComment(int postId, string userId,
            CreateUpdateCommentDto commentDto);

        Task<CommentDto> UpdateComment(int id, CreateUpdateCommentDto commentDto, string userId);

        Task DeleteComment(int id, string userId);
    }
}
