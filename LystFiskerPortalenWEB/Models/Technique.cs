namespace LystFiskerPortalenWEB.Models
{
    public class Technique
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
        public int PostId { get; set; }
        public List<Post>? Post { get; set; }

    }
}
