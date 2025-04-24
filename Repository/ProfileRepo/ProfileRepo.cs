using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.ProfileRepo
{
    public class ProfileRepo : GenericRepo<Profile>, IProfileRepo
    {
        public ProfileRepo(AppDbContext con) : base(con)
        {
        }

        public async Task<Profile?> GetByUserIdAsync(string userId)
        {
            var profile = await dbSet.Where(p => p.UserId == userId)
                .Include(p => p.ApplicationUser)
                .ThenInclude(u => u.posts)
                .FirstOrDefaultAsync();

            return profile;
        }
    }
}
