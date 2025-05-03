using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.DTOs.BookmarkDtos;
using Twitter.Services.BookmarkService_dir;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarkController : BasePlusUserController
    {
        private readonly IBookmarkService bookmarkService;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            this.bookmarkService = bookmarkService;
        }

      // [HttpGet("get-by-id/{id:int}")]
      // public async Task<IActionResult> GetById(int id)
      // {
      //     return null;
      // }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            List<BookmarkDto> bookmarkDtos = await bookmarkService.GetMyBookmarks(userId);

            return Ok(bookmarkDtos);
        }

        [HttpPost("add-to-bookmarks")]
        public async Task<IActionResult> AddBookmark([FromQuery] int postId)
        {
            await bookmarkService.AddToBookmarks(userId, postId);

            return Ok("Added to bookmarks successfully");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBookmark(int id)
        {
            await bookmarkService.RemoveFromBookmarks(userId, id);

            return NoContent();
        }

        // Get Users bookmarked the post by post id -> for admins
        
    }
}
