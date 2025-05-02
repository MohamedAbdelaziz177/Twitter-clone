using Microsoft.EntityFrameworkCore;
using Twitter.Controllers;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.BookmarkRepo
{
    public class BookmarkRepo : GenericRepo<Bookmark>, IBookmarkRepo
    {
        public BookmarkRepo(AppDbContext con) : base(con)
        {
        }

        public async Task<List<Bookmark>?> GetMyBookmarks(string userId)
        {
            return await dbSet.Where(b => b.UserId == userId)
                .Include(b => b.User)
                .ThenInclude(u => u.profile)
                .Include(b => b.Post)
                .ThenInclude(p => p.comments) 
                .ToListAsync();
        }

        public async Task<Bookmark?> GetbookmarkByUserAndPostId(string userId, int postId)
        {
            return await dbSet.FirstOrDefaultAsync(b => b.UserId == userId && b.PostId == postId);
        }
    }
}
