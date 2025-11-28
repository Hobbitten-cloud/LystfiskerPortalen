using System.ComponentModel.DataAnnotations;

namespace LystFiskerPortalenWEB.Models
{
    public class PostImage
    {

        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
