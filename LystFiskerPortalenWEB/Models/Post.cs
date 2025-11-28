using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LystFiskerPortalenWEB.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        //public string? Picture { get; set; }
        public List<PostImage> Images { get; set; } = new();

        [Required]
        public string Description { get; set; }

        public string? Location { get; set; }

        public int? Likes { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public bool IsEditing { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Foreign Keys
        public Lure? Lure { get; set; } 
        public Technique? Technique { get; set; }
        public int? LureId { get; set; }
        public int? TechniqueId { get; set; }
        public Profile Profile { get; set; }
        public string ProfileID {  get; set; }

    }
}
