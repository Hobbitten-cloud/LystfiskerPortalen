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
                    Picture = "public/TestPictures/TestFisk1.png",
                    Description = "En fantastisk dag ved søen med masser af fisk!",
                    Location = "Søen ved Skoven",
                    CreationDate = new DateTime(2024, 5, 10)
                },
                new Post
                {
                    Id = 2,
                    Title = "Havfiskeri eventyr",
                    Picture = "public/TestPictures/TestFisk2.jpg",
                    Description = "En spændende dag på havet med store fangster.",
                    Location = "Kysten ved Byen",
                    CreationDate = new DateTime(2024, 5, 15)
                },
                new Post
                {
                    Id = 3,
                    Title = "Kæmpe blæksprutte fanget!",
                    Picture = "public/TestPictures/TestFisk3.png",
                    Description = "Jeg fangede en kæmpe blæksprutte - det ikke AI",
                    Location = "Byens kyst",
                    CreationDate = new DateTime(2024, 5, 15)
                },
                new Post
                {
                    Id = 4,
                    Title = "Hej Fiskere!",
                    Description = "Søger single lystfiskere i Odense beliggenhed",
                    CreationDate = new DateTime(2024, 5, 15)
                }
            );

        }
    }
}
