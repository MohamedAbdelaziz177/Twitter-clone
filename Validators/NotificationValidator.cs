using FluentValidation;
using Twitter.Enums;
using Twitter.Model;

namespace Twitter.Validators
{
    public class NotificationValidator : AbstractValidator<Notification>
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
        }
    }
}
