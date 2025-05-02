using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.BookmarkRepo
{
    public interface IBookmarkRepo : IGenericRepo<Bookmark>
    {
        Task<List<Bookmark>?> GetMyBookmarks(string userId);
        Task<Bookmark?> GetbookmarkByUserAndPostId(string userId, int postId);
    }
}
