using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Block
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Blocker))]
        public string BlockerId { get; set; } = string.Empty;
        public ApplicationUser Blocker { get; set; } = new();

        [ForeignKey(nameof(Blocked))]
        public string BlockedId { get; set; } = string.Empty;
        public ApplicationUser Blocked { get; set; } = new();
    }
}
