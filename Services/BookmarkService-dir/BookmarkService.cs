using Twitter.DTOs.BookmarkDtos;
using Twitter.Exceptions;
using Twitter.Mappers;
using Twitter.Model;
using Twitter.Unit_of_work;

namespace Twitter.Services.BookmarkService_dir
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IUnitOfWork unitOfWork;

        public BookmarkService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<BookmarkDto>> GetMyBookmarks(string userId)
        {
            List<Bookmark>? lst = await unitOfWork.BookmarkRepo.GetMyBookmarks(userId);

            if (lst == null)
                return new List<BookmarkDto>();
            
            return lst.Select(x => x.toDto()).ToList();
        }

        public async Task AddToBookmarks(string userId, int postId)
        {
            Bookmark bookmark = new();

            bookmark.UserId = userId;
            bookmark.PostId = postId;
            
            await unitOfWork.BookmarkRepo.InsertAsync(bookmark);
        }

        public async Task RemoveFromBookmarks(string userId, int postId)
        {
            Bookmark? bookmark
                = await unitOfWork.BookmarkRepo.GetbookmarkByUserAndPostId(userId, postId);

            if (bookmark == null)
                throw new NotFoundException("You didn't bookmark this post");

            await unitOfWork.BookmarkRepo.DeleteAsync(bookmark.Id);

        }
    }
}
