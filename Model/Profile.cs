using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Profile
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Bio { get; set; } = "";

        public string PhotoUrl { get; set; } = "";

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
    }
}
