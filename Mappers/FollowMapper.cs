using System.Runtime.CompilerServices;
using Twitter.DTOs.FollowDtos;
using Twitter.Model;

namespace Twitter.Mappers
{
    public static class FollowMapper
    {

        public static FollowDto toDto(this Follow follow)
        {
            FollowDto dto = new FollowDto();

            dto.ProfileId = follow.FollowerUser.profile.Id;
            dto.UserName = follow.FollowerUser.FirstName + " " + follow.FollowerUser.LastName;
            dto.ProfileImgUrl = follow.FollowerUser.profile.PhotoUrl;
            dto.UserId = follow.FollowerUserId;

            return dto;
        }
    }
}
