using Microsoft.AspNetCore.Identity;

namespace Twitter.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        public List<Post> posts { get; set; } = new List<Post>();

        public List<Comment> comments { get; set; } = new List<Comment>();


    }
}
