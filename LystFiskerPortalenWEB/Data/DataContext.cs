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
        public DbSet<Technique> Techniques { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Technique>().ToTable("Techniques");

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
            builder.Entity<Technique>().HasData(
                new Technique
                {
                    Id = 1,
                    Name = "Blank",
                    Description = "Blank"
                },
                new Technique
                {
                    Id = 2,
                    Name = "Paternoster-rig",
                    Description = "En af de mest klassiske rigs i både salt- og ferskvand. Et lod sidder nederst, og 1–3 kroge sidder på korte forfang (”trembler”) over loddet."
                },
                new Technique
                {
                    Id = 3,
                    Name = "Carolina-rig",
                    Description = "Et kuglelod glider frit på hovedlinen foran en perle og en svirvel. Herefter kommer et langt forfang med en enkeltkrog."
                },
                new Technique
                {
                    Id = 4,
                    Name = "Texas-rig",
                    Description = "Ligner Carolina-rigget, men loddet sidder direkte foran agnen (typisk med en lille gummistopper). Agnen (ofte en softbait) kan rigges ”weedless”."
                },
                new Technique
                {
                    Id = 5,
                    Name = "Glidende bundrig",
                    Description = "Et lod trækkes frit på hovedlinen, enten gennem et rør eller et glidelod, før en svirvel og et forfang."
                },
                new Technique
                {
                    Id = 6,
                    Name = "Bombarda-rig",
                    Description = "En aflange kasteflåd (bombarda) monteres på linen, så man kan kaste selv små fluer eller lette agn meget langt."
                },
                new Technique
                {
                    Id = 7,
                    Name = "Drop-shot-rig",
                    Description = "En enkeltkrog bindes på linen, og loddet sidder i enden. Krogen kan justeres i præcis den ønskede højde."
                },
                new Technique
                {
                    Id = 8,
                    Name = "Hair-rig",
                    Description = "Krogen bindes på en speciel måde, hvor agnen (fx boilies) sidder på en lille “hair” efter krogen og ikke direkte på krogen."
                },
                new Technique
                {
                    Id = 9,
                    Name = "Float-rig",
                    Description = "Et simpelt rig med flåd, stopperknuder, lodder og krog."
                },
                new Technique
                {
                    Id = 10,
                    Name = "Spinner-rig",
                    Description = "Bruges især til dødagn, hvor et spinnerblad eller rotator tilføjes for at give en livlig gang."
                },
                new Technique
                {
                    Id = 11,
                    Name = "Fladfiskerig",
                    Description = "Specialiseret bundrig med korte forfang og farvede perler/spinnerblade, ofte med to kroge."
                });
        }
    }
}
