using Twitter.DTOs.CommentDtos;
using Twitter.Exceptions;
using Twitter.Mappers;
using Twitter.Model;
using Twitter.Unit_of_work;
using UnauthorizedAccessException = Twitter.Exceptions.UnauthorizedAccessException;

namespace Twitter.Services.CommentService_dir
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommentDto> GetCommentById(int id)
        {
            var comment = await unitOfWork.CommentRepo.GetByIdAsync(id);

            if (comment == null) throw new NotFoundException("Comment not found");

            return comment.toDto();
        }

        public async Task<List<CommentDto>> GetCommentsByPostId(int postId)
        {
            var comments = await unitOfWork.CommentRepo.GetByPostIdAsync(postId);

            if (comments == null || comments.Count == 0)
                throw new NotFoundException("No Comments Available");

            // var CommentDtos = new List<CommentDto>();
            // 
            // foreach(var comment in comments)
            //     CommentDtos.Add(comment.toDto());

            var CommentDtos = comments.Select(comment => comment.toDto()).ToList();

            return CommentDtos;
        }

        public async Task<List<CommentDto>> GetCommentsByUserId(string userId)
        {
            var comments = await unitOfWork.CommentRepo.GetByUserIdAsync(userId);

            if (comments == null || comments.Count == 0)
                throw new NotFoundException("No Comments Available");

            // var CommentDtos = new List<CommentDto>();
            // 
            // foreach (var comment in comments)
            //     CommentDtos.Add(comment.toDto());

            var CommentDtos = comments.Select(comment => comment.toDto()).ToList();

            return CommentDtos;
        }

        public async Task<CommentDto> AddNewComment(int postId, string userId,
            CreateUpdateCommentDto commentDto)
        {
            Comment comment = new Comment();

            comment = comment.fromDto(commentDto);

            comment.UserId = userId;
            comment.PostId = postId;

            await unitOfWork.CommentRepo.InsertAsync(comment);

            return comment.toDto();
        }


        public async Task<CommentDto> UpdateComment(int id, CreateUpdateCommentDto commentDto, string userId)
        {
            Comment? comment = await unitOfWork.CommentRepo.GetByIdAsync(id);

            if (comment == null)
                throw new NotFoundException("No Comment Found");

            if (comment.UserId != userId)
                throw new UnauthorizedAccessException("You are not authorized to edit this comment");

            comment.Content = commentDto.content;

            await unitOfWork.CommentRepo.UpdateAsync(comment);

            return comment.toDto();
        }

        public async Task DeleteComment(int id) 
        {
            await unitOfWork.CommentRepo.DeleteAsync(id);
        }
    }
}
