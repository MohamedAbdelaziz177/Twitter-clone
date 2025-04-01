using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.UserRepo
{
    public class UserRepo : GenericRepo<ApplicationUser>, IUserRepo
    {
        public UserRepo(AppDbContext con) : base(con)
        {
        }
    }
}
