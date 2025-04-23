using FluentValidation;
using Twitter.DTOs.PostDtos;

namespace Twitter.Validators
{
    public class PostDtoValidator : AbstractValidator<CreateUpdatePostDto>
    {
        public PostDtoValidator() 
        {
            RuleFor(p => p.Description)
                .MaximumLength(300).WithMessage("Don't exceed 300 characters")
                .Must(isNonViolantContent).WithMessage("This content violats our polices");

            RuleFor(p => p.Img)
                .Must(hasValidExtension).WithMessage("Image must be one of type \".jpg\", \".jpeg\", \".png\", \".gif\"");
        }

        private bool hasValidExtension(IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return allowedExtensions.Contains(extension);
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

            foreach ( var item in lst)
                if (content.Contains(item))
                    return false;

            return true;
            
        }
    }
}
