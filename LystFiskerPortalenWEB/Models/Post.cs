namespace LystFiskerPortalenWEB.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Picture { get; set; }
        public string Description { get; set; }
        public string? Location { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
