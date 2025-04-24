using Twitter.DTOs.CommentDtos;
using Twitter.Unit_of_work;

namespace Twitter.Services.CommentService_dir
{
    public class CommentService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CommentDto GetCommentById(int id)
        {
            return null;
        }

        public List<CommentDto> GetCommentsByPostId(int postId)
        {
            return null;
        }

        public CommentDto UpdateComment(int id, CreateUpdateCommentDto commentDto)
        {
            return null;
        }

        public CommentDto DeleteComment(int id) 
        {
            return null;
        }
    }
}
