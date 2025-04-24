using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.PostRepo
{
    public class PostRepo : GenericRepo<Post>, IPostRepo
    {
        public PostRepo(AppDbContext con) : base(con)
        {
        }

        public async Task<Post?> GetPostWithCommentsAndUser(int id)
        {
            //Expression<Func<Post, bool>> expr = p => p.Id == id;
            //string includes = "ApplicationUser,comments";

            Post? post = await dbSet.Where(p => p.Id == id)
                .Include(p => p.ApplicationUser)
                .Include(p => p.comments)
                .FirstOrDefaultAsync();

            return post;

        }
    }
}
