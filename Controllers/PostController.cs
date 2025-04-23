using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.DTOs.PostDtos;
using Twitter.Services.PostService_dir;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet("get-by-id/{id:int}")]
        [AllowAnonymous]
        public Task<IActionResult> GetPostById(int id)
        {
            return null;
        }

        [HttpGet("get-my-posts")]
        public Task<IActionResult> GetMyPosts()
        {
            return null;
        }


        [HttpPost("add")]
        public Task<IActionResult> AddPost(CreateUpdatePostDto post)
        {
            return null;
        }

        [HttpPut("update/{id:int}")]
        public Task<IActionResult> UpdatePost([FromRoute] int id, CreateUpdatePostDto post) {

            return null;
        }

        [HttpPost("like")]
        public Task<IActionResult> LikePost([FromQuery] int postId)
        {
            return null;
        }

        [HttpDelete("unlike")]
        public Task<IActionResult> UnlikePost([FromQuery] int postId) { 

            return null;
        }

        [HttpPost("bookmark")]
        public Task<IActionResult> BookmarkPost([FromQuery] int postId) 
        {
            return null;
        }

        [HttpDelete("delete/{id:int}")]
        public Task<IActionResult> DeletePost(int id)
        {
            return null;
        }


    }
}
