using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public bool IsEditing { get; set; }

        public Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
}
