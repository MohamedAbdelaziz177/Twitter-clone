using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.CommentRepo
{
    public class CommentRepo : GenericRepo<Comment>, ICommentRepo
    {
        public CommentRepo(AppDbContext con) : base(con)
        {
        }

        public async Task<List<Comment>?> GetByPostIdAsync(int postId)
        {
            return await dbSet.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<List<Comment>?> GetByUserIdAsync(string userId)
        {
            return await dbSet.Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
