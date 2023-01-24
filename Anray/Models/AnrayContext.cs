using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Anray.Models
{
    public class AnrayContext:IdentityDbContext
    {
        public AnrayContext(DbContextOptions options) : base(options) { }
        public DbSet<Team> Teams { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
