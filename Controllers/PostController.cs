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

        [HttpGet("get-by-id")]
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
        public Task<IActionResult> AddPost(PostDto post)
        {
            return null;
        }

        [HttpPut("update")]
        public Task<IActionResult> UpdatePost(int id, PostDto post) {

            return null;
        }

        public Task<IActionResult> LikePost(int postId)
        {
            return null;
        }

        public Task<IActionResult> UnlikePost(int postId) { 

            return null;
        }

        [HttpPut("delete")]
        public Task<IActionResult> DeletePost(int id)
        {
            return null;
        }


    }
}
