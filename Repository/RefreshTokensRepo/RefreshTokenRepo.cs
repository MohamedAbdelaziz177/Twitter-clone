using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.RefreshTokensRepo
{
    public class RefreshTokenRepo : GenericRepo<RefreshToken>, IRefreshTokenRepo
    {
        public RefreshTokenRepo(AppDbContext context) : base(context) { }

        public async Task<RefreshToken?> GetValidRefreshTokenAsync(string refreshToken)
        {
            var refTok = await dbSet.FirstOrDefaultAsync(r => r.Token == refreshToken 
            && !r.isRevoked
            && r.ExpiryDate > DateTime.Now);

            return refTok;
        }

        
    }
}
