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
    }
}
