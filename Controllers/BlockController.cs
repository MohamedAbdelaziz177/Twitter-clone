using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Services.BlockService_dir;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlockController : BasePlusUserController
    {
        private readonly IBlockService blockService;

        public BlockController(IBlockService blockService)
        {
            this.blockService = blockService;
        }

        [HttpPost("block")]
        public async Task<IActionResult> BlockUser([FromQuery] string blockedId)
        {
            await blockService.BlockUser(userId, blockedId);

            return NoContent();
        }

        [HttpDelete("unblock")]
        public async Task<IActionResult> UnblockUser([FromQuery] string blockedId)
        {
            await blockService.UnblockUser(userId, blockedId);

            return NoContent();
        }

    }
}
