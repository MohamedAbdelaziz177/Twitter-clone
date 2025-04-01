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
    }
}
