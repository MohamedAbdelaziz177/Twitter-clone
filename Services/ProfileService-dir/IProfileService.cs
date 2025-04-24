using Twitter.DTOs.ProfileDtos;

namespace Twitter.Services.ProfileService_dir
{
    public interface IProfileService
    {
        Task<ProfileDto> GetById(int id);
        Task<ProfileDto> GetByUserId(string userId);

        Task<ProfileDto> UpdateProfile(int id, UpdateProfileDto profileDto);
    }
}
