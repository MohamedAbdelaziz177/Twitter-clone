using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet("get-by-id")]
        public Task<IActionResult> GetById(int id) 
        {
            return null;
        }

        [HttpGet("get-my-profile")]
        public Task<IActionResult> GetMyProfile() 
        {
            return null;
        }

        [HttpPut("update-my-profile")]
        public Task<IActionResult> UpdateMyProfile()
        {
            return null;
        }

    }
}
