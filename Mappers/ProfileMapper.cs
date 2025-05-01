using Twitter.DTOs.PostDtos;
using Twitter.DTOs.ProfileDtos;
using Twitter.Model;

namespace Twitter.Mappers
{
    public static class ProfileMapper
    {
        public static ProfileDto toDto(this Profile profile)
        {
            ProfileDto dto = new ProfileDto();

            dto.Bio = profile.Bio;
            dto.Name = profile.Name;
            dto.ImgUrl = profile.PhotoUrl;
            dto.userId = profile.UserId;

            foreach (Post post in profile.ApplicationUser.posts)
                dto.PostDtos.Add(post.toDto());

            return dto;
        }

        public static Profile fromDto(this Profile profile, UpdateProfileDto profileDto)
        {
            Profile prof = new();

            prof.Bio = profileDto.Bio;
            prof.Name = profileDto.Name;
            prof.PhotoUrl = "";

            return prof;
        }
    }
}
