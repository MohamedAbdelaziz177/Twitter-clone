using FluentValidation;
using Twitter.DTOs.CommentDtos;

namespace Twitter.Validators
{
    public class CommentDtoValidator : AbstractValidator<CreateUpdateCommentDto>
    {
        public CommentDtoValidator() 
        {
            RuleFor(c => c.content).NotEmpty().WithMessage("Comment cannot be empty")
                .MaximumLength(80).WithMessage("Don't exceed 80 characters")
                .Must(isNonViolantContent).WithMessage("This content violates our polices");
        }

        private bool isNonViolantContent(string content)
        {
            var lst = new List<string>() {
                "sex",
                "fuck",
                "motherfucker",
                "SEX",
                "FUCK",
                "pussy",
                "dick",
                "Pussy",
                "Dick",
                "Tits",
                "bobs"
            };

            foreach (var item in lst)
                if (content.Contains(item))
                    return false;

            return true;

        }
    }
}
