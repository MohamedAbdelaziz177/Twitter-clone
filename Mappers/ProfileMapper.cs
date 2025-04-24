using Twitter.DTOs.PostDtos;
using Twitter.DTOs.ProfileDtos;
using Twitter.Model;

namespace Twitter.Mappers
{
    public static class ProfileMapper
    {
        public static ProfileDto toDto(Profile profile)
        {
            ProfileDto dto = new ProfileDto();

            dto.Bio = profile.Bio;
            dto.Name = profile.Name;
            dto.ImgUrl = profile.PhotoUrl;

            foreach (Post post in profile.ApplicationUser.posts)
                dto.PostDtos.Add(post.toDto());

            return dto;
        }
    }
}
