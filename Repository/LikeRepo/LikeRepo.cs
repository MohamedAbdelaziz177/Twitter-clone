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
    }
}
