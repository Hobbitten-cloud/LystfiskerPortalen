using System.ComponentModel.DataAnnotations;
using NuGet.DependencyResolver;

namespace LystFiskerPortalenWEB.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public string? Picture { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
