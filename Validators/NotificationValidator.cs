using FluentValidation;
using Twitter.DTOs.Notification;
using Twitter.Enums;
using Twitter.Model;

namespace Twitter.Validators
{
    public class NotificationValidator : AbstractValidator<NotificationDto>
    {
        public NotificationValidator() 
        {
            RuleFor(n => n.PostId)
                .NotNull()
                .When(n => n.Type == NotificationType.POST)
                .WithMessage("PostId cannot be null if the notification is related to a post");

            RuleFor(n => n.CommentId)
                .NotNull()
                .When(n => n.Type != NotificationType.COMMENT)
                .WithMessage("CommentId cannot be null if the notification is related to a comment");

            RuleFor(n => n.LikeId)
                .NotNull()
                .When(n => n.Type != NotificationType.LIKE)
                .WithMessage("LikeId cannot be null if the notification is related to a LIKE");

            RuleFor(n => n.FollowId)
                .NotNull()
                .When(n => n.Type != NotificationType.FOLLOW) 
                .WithMessage("FollowId cannot be null if the notification is related to a FOLLOW");

        }
    }
}
