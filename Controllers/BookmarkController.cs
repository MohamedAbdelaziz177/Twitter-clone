using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {

        public BookmarkController() { }

        [HttpGet("get-by-id/{id:int}")]
        public Task<IActionResult> GetById(int id)
        {
            return null;
        }

        [HttpGet("get-all")]
        public Task<IActionResult> GetAll()
        {
            return null;
        }

        [HttpDelete("delete")]
        public Task<IActionResult> DeleteBookmark(int id)
        {
            return null;
        }

        // Get Users bookmarked the post by post id -> for admins
        
    }
}
