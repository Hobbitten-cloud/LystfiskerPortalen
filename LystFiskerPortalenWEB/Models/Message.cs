using System.ComponentModel.DataAnnotations.Schema;

namespace LystFiskerPortalenWEB.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateSend { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        [ForeignKey(nameof(SenderId))]
        public Profile Sender {  get; set; }
        [ForeignKey(nameof(ReceiverId))]
        public Profile Receiver { get; set; }
       
    }
}
