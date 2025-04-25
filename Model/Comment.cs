using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        [ForeignKey(nameof(Post))]
        public int PostId {  get; set; }
        public Post Post { get; set; } = new Post();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = "";
        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
    }
}
