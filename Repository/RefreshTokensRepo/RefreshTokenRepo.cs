using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.RefreshTokensRepo
{
    public class RefreshTokenRepo : GenericRepo<RefreshToken>, IRefreshTokenRepo
    {
        public RefreshTokenRepo(AppDbContext context) : base(context) { }
    }
}
