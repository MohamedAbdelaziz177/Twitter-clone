using System.ComponentModel.DataAnnotations.Schema;
using Twitter.Enums;
using Twitter.Model;

namespace Twitter.DTOs.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }

        public NotificationType Type { get; set; }

        public string Description { get; set; } = string.Empty;

        public int? PostId { get; set; }

        public int? CommentId { get; set; }

        public int? LikeId { get; set; }

        public int? FollowId { get; set; }

    }
}
