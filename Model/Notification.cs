using System.ComponentModel.DataAnnotations.Schema;
using Twitter.Enums;

namespace Twitter.Model
{
    public class Notification
    {
        public int Id { get; set; }

        public NotificationType Type { get; set; }

        public string Description { get; set; } = string.Empty;

        [ForeignKey(nameof(Post))]
        public int? PostId { get; set; }

        public Post? Post { get; set; }

        [ForeignKey(nameof(Comment))]
        public int? CommentId { get; set; }

        public Comment? Comment { get; set; }


    }
}
