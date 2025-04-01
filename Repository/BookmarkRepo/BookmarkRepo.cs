using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.BookmarkRepo
{
    public class BookmarkRepo : GenericRepo<Bookmark>, IBookmarkRepo
    {
        public BookmarkRepo(AppDbContext con) : base(con)
        {
        }
    }
}
