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
    }
}
