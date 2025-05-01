using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.FollowRepo
{
    public class FollowRepo : GenericRepo<Follow>, IFollowRepo
    {
        public FollowRepo(AppDbContext con) : base(con)
        {
        }

        public async Task<Follow?> GetFollowIncludingUsersAndProfiles(int id)
        {
            return await dbSet.Where(f => f.Id == id).Include(f => f.FollowerUser)
                .ThenInclude(u => u.profile)
                .Include(f => f.FollowedUser)
                .ThenInclude(u => u.profile)
                .FirstOrDefaultAsync();
        }

        public async Task<Follow?> GetByFollowerAndFollowedId(string followerId, string followedId)
        {
            return
                await dbSet.FirstOrDefaultAsync(f => f.FollowerUserId == followerId &&
            f.FollowedUserId == followedId
            && !f.IsDeleted);
        }

        public async Task<List<Follow>?> GetUserFollowings(string userId)
        {
            return await dbSet.Where(f => f.FollowedUserId ==  userId && !f.IsDeleted).ToListAsync();
        }

        public async Task<List<Follow>?> GetUserFollowers(string userId)
        {
            return await dbSet.Where(f => f.FollowerUserId == userId && !f.IsDeleted).ToListAsync();

        }
    }
}
