using System.ComponentModel.DataAnnotations;

namespace LystFiskerPortalenWEB.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Picture { get; set; }
        [Required]
        public string Description { get; set; }
        public string? Location { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        //Forgin Keys
        public Lure? Lure { get; set; } 
        public Technique? Technique { get; set; }
        public int LureId { get; set; }
        public int TechniqueID { get; set; }
    }
}
