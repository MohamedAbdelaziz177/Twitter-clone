using Twitter.DTOs.FollowDtos;
using Twitter.Exceptions;
using Twitter.Mappers;
using Twitter.Model;
using Twitter.Unit_of_work;

namespace Twitter.Services.FollowService_dir
{
    public class FollowService : IFollowService
    {
        private readonly IUnitOfWork unitOfWork;

        public FollowService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task FollowUser(string followerId, string followedId)
        {
            var user = await unitOfWork.UserRepo.GetAsync(x => x.Id == followedId);

            if (user == null)
                throw new NotFoundException("No such user exists");

            Follow follow = new();

            follow.FollowerUserId = followerId;
            follow.FollowedUserId = followedId;

            await unitOfWork.FollowRepo.InsertAsync(follow);
        }

        public async Task UnfollowUser(string followerId, string followedId)
        {
            Follow? follow = 
                await unitOfWork.FollowRepo.GetByFollowerAndFollowedId(followerId, followedId);

            if (follow == null)
                throw new NotFoundException("You are not following this user");

            follow.IsDeleted = true;

            await unitOfWork.FollowRepo.UpdateAsync(follow);
            
        }

        public async Task<bool> IsFollowedByMe(string followerId, string followedId)
        {
            Follow? follow =
                await unitOfWork.FollowRepo.GetByFollowerAndFollowedId(followerId, followedId);

            return follow != null;
        }

        public async Task<List<FollowDto>> GetUsersFollowings(string userId)
        {
            var followingLst = 
                await unitOfWork.FollowRepo.GetUserFollowings(userId);

            if(followingLst == null)
                return new List<FollowDto>();

            var lstDtos = followingLst.Select(f => f.toDto()).ToList();

            return lstDtos;
        }

        public async Task<List<FollowDto>> GetUsersFollowers(string userId)
        {
            var followingLst =
                await unitOfWork.FollowRepo.GetUserFollowers(userId);

            if (followingLst == null)
                return new List<FollowDto>();

            var lstDtos = followingLst.Select(f => f.toDto()).ToList();

            return lstDtos;
        }

        public async Task<List<FollowDto>> GetMutualFollower(string myId, string userId)
        {
            var lst1 = await unitOfWork.FollowRepo.GetUserFollowings(myId); // MyFollowings
            var lst2 = await unitOfWork.FollowRepo.GetUserFollowers(userId); //HisFollowers

            if(lst1 == null || lst2 == null)
                return new List<FollowDto>();

            var res = lst1.Intersect(lst2);                                 // Their intersection

            return res.Select(e => e.toDto()).ToList();
        }


    }
}
