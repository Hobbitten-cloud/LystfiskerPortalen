namespace LystFiskerPortalenWEB.Models
{
    public class Lure
    {
        public int Id { get; set; }
        public string Color { get; set; }

        public string Name { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        private List<Lure> Lures { get; set; } = new List<Lure>();
    }
}
