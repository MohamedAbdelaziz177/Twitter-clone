using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Twitter.Model;

namespace Twitter.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    { 
        public AppDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Post> Posts { get; set; }

       //public DbSet<Follow> Follows { get; set; }
       //
       //public DbSet<Comment> Comments { get; set; }
       //
       //public DbSet<Like> Likes { get; set; }
    }
}
