using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.RefreshTokensRepo
{
    public class RefreshTokenRepo : GenericRepo<RefreshToken>, IRefreshTokenRepo
    {
        public RefreshTokenRepo(AppDbContext context) : base(context) { }

        public async Task<RefreshToken?> GetValidRefreshTokenAsync(string refreshToken, string userId)
        {
            var refTok = await dbSet.Include(rt => rt.AppUser)
                              .FirstOrDefaultAsync(x => x.Token == refreshToken
                                                                     && x.ExpiryDate > DateTime.Now
                                                                     && !x.isRevoked
                                                                     && x.AppUserId == userId);

            return refTok;
        }

        
    }
}
