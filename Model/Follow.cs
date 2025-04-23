using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Follow
    {
        public int Id { get; set; }

        [ForeignKey(nameof(FollowedUser))]
        public string FollowedUserId {  get; set; } = string.Empty;

        public ApplicationUser FollowedUser {  get; set; } = new ApplicationUser();


        [ForeignKey(nameof(FollowerUser))]
        public string FollowerUserId {  get; set; } = string.Empty;

        public ApplicationUser FollowerUser { get; set; } = new ApplicationUser();

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
