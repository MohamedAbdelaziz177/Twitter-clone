using Twitter.DTOs.BookmarkDtos;

namespace Twitter.Services.BookmarkService_dir
{
    public interface IBookmarkService
    {
        Task<List<BookmarkDto>> GetMyBookmarks(string userId);
        Task AddToBookmarks(string userId, int postId);

        Task RemoveFromBookmarks(string userId, int postId);
    }
}
