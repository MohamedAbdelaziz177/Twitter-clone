using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Twitter.Model;

namespace Twitter.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    { 
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ApplicationUser)
                .WithMany(u => u.comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Set Null instead of Cascade

        }


        public DbSet<Post> Posts { get; set; }

        public DbSet<Profile> Profiles { get; set; }

       //public DbSet<Follow> Follows { get; set; }
       
        public DbSet<Comment> Comments { get; set; }
       //
       //public DbSet<Like> Likes { get; set; }
    }
}
