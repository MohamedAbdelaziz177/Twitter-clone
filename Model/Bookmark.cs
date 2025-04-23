using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Bookmark
    {

        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = new ApplicationUser();

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post Post { get; set; } = new Post();

        public DateTime? BookmarkedAt { get; set; } = DateTime.Now;

        
    }
}
