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

            builder.Entity<Post>().ToTable("Posts");

            builder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Fisketur ved søen",
                    Picture = "fisketur1.jpg",
                    Description = "En fantastisk dag ved søen med masser af fisk!",
                    Location = "Søen ved Skoven",
                    CreationDate = new DateTime(2024, 5, 10)
                },
                new Post
                {
                    Id = 2,
                    Title = "Havfiskeri eventyr",
                    Picture = "havfiskeri.jpg",
                    Description = "En spændende dag på havet med store fangster.",
                    Location = "Kysten ved Byen",
                    CreationDate = new DateTime(2024, 5, 15)
                }
            );

        }
    }
}
