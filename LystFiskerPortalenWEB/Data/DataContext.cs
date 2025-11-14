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

        public DbSet<Lure> Lures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Profile>().ToTable("Profiles"); 
            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Technique>().ToTable("Techniques");
            builder.Entity<Lure>().ToTable("Lures");


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

            //seeder tech
            
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
                }
            );
            

            
            
            builder.Entity<Lure>().HasData(
               new Lure
               {
                   Id = 1,
                   Name = "Blank",
                   Color = "Blank",
                   Weight = 0000,
                   Type = "Blank"
               },
               new Lure
               {
                   Id = 2,
                   Name = "Möresilda",
                   Color = "Sølv/blå",
                   Weight = 7,
                   Type = "Klassisk kystblink til havørred, hornfisk og andre rovfisk. Går lidt dybere og kaster langt."
               },
               new Lure
               {
                   Id = 3,
                   Name = "Abu Garcia Toby",
                   Color = "Sølv",
                   Weight = 7,
                   Type = "Universelt blink til både sø og kyst. Fisker godt efter gedde, havørred, laks og aborre."
               },
               new Lure
               {
                   Id = 4,
                   Name = "Savage Gear Sandeel Surf Seeker",
                   Color = "pearl/white",
                   Weight = 35,
                   Type = "Moderne long-cast kystblink. Perfekt til havørred, især i hårdt vejr og lange kasteafstande."
               },
               new Lure
               {
                   Id = 5,
                   Name = "Hansen Flash",
                   Color = "kobber/orange",
                   Weight = 15,
                   Type = "Kystblink med livlig gang. Godt til havørred på lavere vand."
               },
               new Lure
               {
                   Id = 6,
                   Name = "Snaps",
                   Color = "chartreuse",
                   Weight = 25,
                   Type = "Kæmpe favorit blandt danske kystfiskere. Særligt effektiv på havørred og hornfisk."
               },
               new Lure
               {
                   Id = 7,
                   Name = "Abu Garcia Atom",
                   Color = "sølv/black stripes",
                   Weight = 40,
                   Type = "Geddeblink nr. 1 i mange år. Bred, vuggende gang – perfekt i søer og brakvand."
               },
               new Lure
               {
                   Id = 8,
                   Name = "Blue Fox Lucius",
                   Color = "Firetiger",
                   Weight = 27,
                   Type = "Geddeblink til både lavt og dybt vand. God til at provokere hug i uklart vand."
               },
               new Lure
               {
                   Id = 9,
                   Name = "Solvkroken Stingsilda",
                   Color = "rød/sølv",
                   Weight = 18,
                   Type = "Kraftigt, tungt blink til havfiskeri og kyst. Bruges ofte til torsk, makrel og havørred."
               },
               new Lure
               {
                   Id = 10,
                   Name = "Mepps Syclops",
                   Color = "sølv/blue stripes",
                   Weight = 12,
                   Type = "Allround blink med meget “flappende” gang. Bruges til både aborre, gedde og laks."
               },
               new Lure
               {
                   Id = 11,
                   Name = "Westin D360",
                   Color = "Pink Panther",
                   Weight = 22,
                   Type = "Slankt long-distance blink – super til havørred, især i klart vand."
               }
            );              
        }
    }
}
