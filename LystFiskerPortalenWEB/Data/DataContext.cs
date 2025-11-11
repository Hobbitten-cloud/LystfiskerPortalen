using LystFiskerPortalenWEB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LystFiskerPortalenWEB.Data
{
    public class DataContext : IdentityDbContext<Profile>
    {
        public DataContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        }
    }
}
