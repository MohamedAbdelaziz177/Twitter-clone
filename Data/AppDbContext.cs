using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Twitter.Model;

namespace Twitter.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    { 
        public AppDbContext(DbContextOptions options) : base(options) { }
       
    }
}
