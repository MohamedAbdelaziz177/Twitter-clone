using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.DTOs.ProfileDtos;
using Twitter.Services.ProfileService_dir;

namespace Twitter.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProfileController : BasePlusUserController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }


        [HttpGet("get-by-id/{id:int}")]
        public async Task<IActionResult> GetById(int id) 
        {
            ProfileDto prof = await profileService.GetById(id);
            return Ok(prof);
        }

        [HttpGet("get-my-profile")]
        public async Task<IActionResult> GetMyProfile() 
        {
            ProfileDto prof = await profileService.GetByUserId(userId);
            return Ok(prof);
        }

        [HttpPut("update-my-profile/{id:int}")]
        public async Task<IActionResult> UpdateMyProfile([FromRoute] int id, UpdateProfileDto updateProfileDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            ProfileDto profileDto = await profileService.UpdateProfile(id, updateProfileDto);

            return NoContent();
        }

    }
}
