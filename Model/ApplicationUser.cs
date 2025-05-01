using Microsoft.AspNetCore.Identity;

namespace Twitter.Model
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<RefreshToken> RefreshTokens { get; set; } = new();

        public List<Post> posts { get; set; } = new List<Post>();

        public List<Comment> comments { get; set; } = new();

        public List<Like> likes { get; set; } = new();

        public List<Follow> follows { get; set; } = new ();

        public List<Bookmark> bookmarks { get; set; } = new();

        public Profile profile { get; set; } = new();

    }
}
