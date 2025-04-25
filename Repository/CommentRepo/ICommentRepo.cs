using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.CommentRepo
{
    public interface ICommentRepo : IGenericRepo<Comment>
    {
        Task<List<Comment>?> GetByPostIdAsync(int postId);

        Task<List<Comment>?> GetByUserIdAsync(string userId);
    }
}
