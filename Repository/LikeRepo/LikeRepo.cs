using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.LikeRepo
{
    public class LikeRepo : GenericRepo<Like>, ILikeRepo
    {
        public LikeRepo(AppDbContext con) : base(con)
        {
        }

        public async Task<bool> IsLikedByUser(string userId, int PostId)
        {
            var like =
            await dbSet.FirstOrDefaultAsync(l => l.UserId == userId && l.PostId == PostId);

            return like != null;
        }

        public async Task<Like?> GetByUserAndPost(string userId, int PostId)
        {
            return await dbSet.FirstOrDefaultAsync(l => l.UserId == userId && l.PostId == PostId);
        }

        public async Task<List<Like>?> GetByPostId(int postId)
        {
            return await dbSet.Where(l => l.PostId == postId)
                .Include(l => l.User)
                .ThenInclude(u => u.profile).ToListAsync();

        }
    }
}
