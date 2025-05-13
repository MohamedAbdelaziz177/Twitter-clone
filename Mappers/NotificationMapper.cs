using System.Runtime.CompilerServices;
using Twitter.DTOs.Notification;
using Twitter.Enums;
using Twitter.Model;

namespace Twitter.Mappers
{
    public static class NotificationMapper
    {
        public static NotificationDto toDto(this Notification notification)
        {
            NotificationDto dto = new NotificationDto();

            dto.Id = notification.Id;
            dto.Description = notification.Description;
            dto.Type = notification.Type;

            if(dto.Type == NotificationType.POST)
                dto.PostId = notification.PostId;

            else if(dto.Type == NotificationType.COMMENT)
                dto.CommentId = notification.CommentId;
            
            else if(dto.Type == NotificationType.LIKE)
                dto.LikeId = notification.LikeId;

            else if(dto.Type == NotificationType.FOLLOW)
                dto.FollowId = notification.FollowId;

            return dto;
        }

        public static Notification fromDto(this Notification notification, NotificationDto dto)
        {
            Notification noti = new();

            noti.Id = dto.Id;
            noti.Description = dto.Description;
            noti.Type = dto.Type;

            if(noti.Type == NotificationType.POST)
                noti.PostId = dto.PostId;

            if(noti.Type == NotificationType.COMMENT)
                noti.CommentId = dto.CommentId;

            if(noti.Type == NotificationType.FOLLOW)
                noti.FollowId = dto.FollowId;

            if(noti.Type == NotificationType.LIKE)
                noti.LikeId = dto.LikeId;

            return noti;
        }
    }
}
