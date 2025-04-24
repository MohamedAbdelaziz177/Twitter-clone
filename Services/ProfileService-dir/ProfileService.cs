using Twitter.DTOs.ProfileDtos;
using Twitter.Exceptions;
using Twitter.Mappers;
using Twitter.Model;
using Twitter.Services.ImgService_dir;
using Twitter.Unit_of_work;

namespace Twitter.Services.ProfileService_dir
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImgService imgService;

        public ProfileService(IUnitOfWork unitOfWork, IImgService imgService) 
        {
            this.unitOfWork = unitOfWork;
            this.imgService = imgService;
        }

        public async Task<ProfileDto> GetById(int id)
        {
            var profile =  await unitOfWork.profileRepo.GetByIdAsync(id);

            if (profile == null) throw new NotFoundException("Profile not found");

            return profile.toDto();
        }

        public async Task<ProfileDto> GetByUserId(string userId)
        {
            var profile = await unitOfWork.profileRepo.GetByUserIdAsync(userId);

            if (profile == null) throw new NotFoundException("Profile not found");

            return profile.toDto();
        }


        public async Task<ProfileDto> UpdateProfile(int id, UpdateProfileDto profileDto)
        {
            var profile = await unitOfWork.profileRepo.GetByIdAsync(id);

            if (profile == null) throw new NotFoundException("Profile not found");

            profile = profile.fromDto(profileDto);
            profile.PhotoUrl = await imgService.SaveImageAndGetUrl(profileDto.Img);

            await unitOfWork.profileRepo.UpdateAsync(profile); 

            return profile.toDto();

        }
    }
}
