using Microsoft.EntityFrameworkCore;

namespace Twitter.Data
{
    public class AppDbContext : DbContext 
    { 
        public AppDbContext(DbContextOptions options) : base(options) { }

       
    }
}
