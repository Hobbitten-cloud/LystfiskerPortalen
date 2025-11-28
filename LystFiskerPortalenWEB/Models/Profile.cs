using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace LystFiskerPortalenWEB.Models
{
    public class Profile : IdentityUser
    {
        // ID, Phonenumber, Email, Password and UserName are inherited from IdentityUser
        
        [Required]
        public string  Role { get; set; }

        public string ImagePath { get; set; }

        public List<Post> Posts { get; set; }

        [InverseProperty(nameof(Message.Sender))]
        public virtual ICollection<Message> SentMessages { get; set; }

        [InverseProperty(nameof(Message.Receiver))]
        public virtual ICollection<Message> ReceivedMessages { get; set; }


    }
}
