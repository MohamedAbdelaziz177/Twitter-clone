using FluentValidation;
using Twitter.DTOs.ProfileDtos;

namespace Twitter.Validators
{
    public class ProfileDtoValidator : AbstractValidator<UpdateProfileDto>
    {
        public ProfileDtoValidator() 
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Profile name cannot be empty")
                .MaximumLength(20).WithMessage("profile name cannot exceed 20 characters")
                .MinimumLength(5).WithMessage("profile name cannot be below 5 characters");

            RuleFor(p => p.Bio)
                .MaximumLength(100).WithMessage("profile Bio cannot exceed 100 characters")
                .Must(isNonViolantContent).WithMessage("This content violats our polices");

            RuleFor(p => p.Img)
                .Must(hasValidExtension).WithMessage("\"Image must be one of type \".jpg\", \".jpeg\", \".png\"");

        }


        private bool hasValidExtension(IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png"};
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

            foreach (var item in lst)
                if (content.Contains(item))
                    return false;

            return true;

        }
    }
}
