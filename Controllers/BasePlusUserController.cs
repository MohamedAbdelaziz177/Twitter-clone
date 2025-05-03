using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BasePlusUserController : ControllerBase
    {
        protected string userId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
}
