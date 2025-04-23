using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Like
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public Post Post { get; set; } = new();


        [ForeignKey(nameof(User))]
        public string UserId {  get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = new();
    }
}
