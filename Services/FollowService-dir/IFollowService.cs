using Twitter.DTOs.FollowDtos;

namespace Twitter.Services.FollowService_dir
{
    public interface IFollowService
    {
        Task FollowUser(string followerId, string followedId);

        Task UnfollowUser(string followerId, string followedId);

        Task<bool> IsFollowedByMe(string followerId, string followedId);

        Task<List<FollowDto>> GetUsersFollowings(string userId);

        Task<List<FollowDto>> GetUsersFollowers(string userId);
    }
}
