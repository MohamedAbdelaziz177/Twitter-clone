using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.FollowRepo
{
    public interface IFollowRepo : IGenericRepo<Follow>
    {
        Task<List<Follow>?> GetUserFollowers(string userId);
        Task<List<Follow>?> GetUserFollowings(string userId);
        Task<Follow?> GetByFollowerAndFollowedId(string followerId, string followedId);
    }
}
