using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Model;
using Twitter.Services.NotificationService;
using Twitter.Unit_of_work;

namespace Twitter.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]

    [Authorize]
    public class NotificationController : BasePlusUserController
    {
        private readonly INotificationService notificationService;

        
        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpGet("get-my-notifications")]
        public async Task<IActionResult> GetMyNotfications()
        {
            return Ok(await notificationService.GetMyNotifications(userId));
        }

        [HttpDelete("delete-notification/{id:int}")]
        public async Task<IActionResult> DeleteNotificationById([FromRoute] int id) 
        {
            await notificationService.DeleteTaskById(id);

            return NoContent();
        }
    }
}
