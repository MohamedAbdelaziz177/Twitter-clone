using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Twitter.DTOs.PostDtos;
using Twitter.DTOs.ProfileDtos;
using Twitter.Services.BookmarkService_dir;
using Twitter.Services.PostService_dir;
using Twitter.Services.ProfileService_dir;

namespace Twitter.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : BasePlusUserController
    {
        private readonly IPostService postService;
        private readonly IProfileService profileService;
        private readonly IBookmarkService bookmarkService;

        public PostController(IPostService postService,
            IProfileService profileService,
            IBookmarkService bookmarkService)
        {
            this.postService = postService;
            this.profileService = profileService;
            this.bookmarkService = bookmarkService;
        }

        [HttpGet("get-by-id/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPostById(int id)
        {
            PostDto post = await postService.GetById(id);

            return Ok(post);
        }

        [HttpGet("get-my-posts")]
        public async Task<IActionResult> GetMyPosts()
        {
            return Ok(await profileService.GetByUserId(userId));
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddPost(CreateUpdatePostDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostDto postDto = await postService.AddNewPost(post, userId);

            return CreatedAtAction("GetPostById", new
            {
                id = postDto.Id,
                postDto
            });
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdatePost([FromRoute] int id, CreateUpdatePostDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await postService.UpdatePost(id, post, userId);
            return NoContent();
        }

        [HttpPost("like")]
        public async Task<IActionResult> LikePost([FromQuery] int postId)
        {
            
            await postService.LikePost(userId, postId);
            return NoContent();
        }

        [HttpDelete("unlike")]
        public async Task<IActionResult> UnlikePost([FromQuery] int postId)
        {
            
            await postService.UnlikePost(userId, postId);
            return NoContent();
        }

        [HttpPost("bookmark")]
        public async Task<IActionResult> BookmarkPost([FromQuery] int postId) 
        {
            
            await bookmarkService.AddToBookmarks(userId, postId);
            return Ok();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeletePost(int id)
        {
          
            await postService.Delete(id, userId);
            return NoContent();
        }


    }
}
