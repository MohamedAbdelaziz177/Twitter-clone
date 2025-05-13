using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.DTOs.FollowDtos;
using Twitter.Services.FollowService_dir;

namespace Twitter.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    public class FollowController : BasePlusUserController
    {
        private readonly IFollowService followService;

        public FollowController(IFollowService followService)
        {
            this.followService = followService;
        }

        [AllowAnonymous]
        [HttpGet("get-followers")]
        public async Task<IActionResult> GetFollowers([FromQuery] string userId)
        {
            var lst = await followService.GetUsersFollowers(userId);

            return Ok(lst);
        }

        [AllowAnonymous]
        [HttpGet("get-followings")]
        public async Task<IActionResult> GetFollowings([FromQuery] string userId) 
        {
            var lst = await followService.GetUsersFollowings(userId);

            return Ok(lst);
        }

        [HttpGet("get-mutual-followes")]
        public async Task<IActionResult> GetMutualFollowers([FromQuery] string targetUserId)
        {
            List<FollowDto> followDtos = await followService.GetMutualFollower(userId, targetUserId);

            return Ok(followDtos);
        }

        [HttpPost("follow")]
        public async Task<IActionResult> FollowUser([FromQuery] string targetUserId)
        {
            await followService.FollowUser(userId, targetUserId);

            return NoContent();
        }

        [HttpDelete("unfollow")]
        public async Task<IActionResult> UnfollowUser([FromQuery] string targetUserId)
        {
            await followService.UnfollowUser(userId, targetUserId);

            return NoContent();
        }

       
    }
}
