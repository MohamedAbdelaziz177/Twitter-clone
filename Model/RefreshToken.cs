using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Model
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        public string AppUserId { get; set; } = string.Empty;

        [ForeignKey("AppUserId")]
        public ApplicationUser AppUser { get; set; } = default!;
        public string Token { get; set; } = string.Empty;
        public bool isRevoked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
