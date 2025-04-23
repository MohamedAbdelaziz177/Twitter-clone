using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.DTOs.CommentDtos;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        [HttpGet("get-by-id/{id:int}")]
        public IActionResult GetById(int id)
        {
            return null;
        }

        [HttpGet("get-by-postId")]
        public IActionResult GetByPostId([FromQuery] int postId)
        {
            return null;
        }

        [HttpGet("get-by-userId")]
        public IActionResult GetByUserId(string userId)
        {
            return null;
        }


        [HttpPost("add")]
        public IActionResult AddComment(CreateUpdateCommentDto comment)
        {
            return null;
        }

        [HttpPost("update/{id:int}")]
        public IActionResult EditComment([FromRoute] int id, CreateUpdateCommentDto comment) 
        {
            return null;
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteComment(int id)
        {
            return null;
        }
    }
}
