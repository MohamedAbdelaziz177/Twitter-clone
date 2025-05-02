using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.LikeRepo
{
    public interface ILikeRepo : IGenericRepo<Like>
    {
        Task<bool> IsLikedByUser(string userId, int PostId);

        Task<Like?> GetByUserAndPost(string userId, int PostId);

        Task<List<Like>?> GetByPostId(int postId);
    }
}
