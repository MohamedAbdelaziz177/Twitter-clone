using System.Runtime.CompilerServices;
using Twitter.DTOs.AuthDtos;
using Twitter.DTOs.LikeDtos;
using Twitter.Model;

namespace Twitter.Mappers
{
    public static class LikeMapper
    {
        public static LikeDto toDto(this Like like)
        {

            LikeDto dto = new();

            dto.UserId = like.UserId;
            dto.UserName = like.User.FirstName + " " + like.User.LastName;
            dto.ProfileImgUrl = like.User.profile.PhotoUrl;
            dto.ProfileId = like.User.profile.Id;

            return dto;

        }
    }
}
