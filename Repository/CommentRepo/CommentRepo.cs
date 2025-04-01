using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.CommentRepo
{
    public class CommentRepo : GenericRepo<Comment>, ICommentRepo
    {
        public CommentRepo(AppDbContext con) : base(con)
        {
        }
    }
}
