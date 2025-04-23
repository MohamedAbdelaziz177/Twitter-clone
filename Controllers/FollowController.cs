using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowController : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet("get-followers")]
        public Task<IActionResult> GetFollowers([FromQuery] string userId)
        {
            return null;
        }

        [AllowAnonymous]
        [HttpGet("get-followings")]
        public Task<IActionResult> GetFollowings([FromQuery] string userId) 
        {
            return null;
        }

        [HttpGet("get-mutual-followes")]
        public Task<IActionResult> GetMutualFollowers([FromQuery] string userId)
        {
            return null;
        }

        [HttpPost("follow")]
        public Task<IActionResult> FollowUser([FromQuery] string userId)
        {
            return null;
        }

        [HttpDelete("unfollow")]
        public Task<IActionResult> UnfollowUser([FromQuery] string userId)
        {
            return null;
        }

       
    }
}
