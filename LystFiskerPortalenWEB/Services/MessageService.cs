using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
namespace LystFiskerPortalenWEB.Services
{
    public class MessageService : IMessageService
    {
        private DataContext _dataContext;

        public MessageService(DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        public async Task<List<Message>> GetConversationAsync(string userId1, string userId2)
        {
            List<Message> Conversation = await _dataContext.Messages
                .Include(m => m.Receiver)
                .Include(m => m.Sender)
                .Where(m => (m.SenderId == userId1 || m.SenderId == userId2)
                    && (m.ReceiverId == userId1 || m.ReceiverId == userId2))
                .ToListAsync();
            return Conversation;
        }

        public async Task SaveMessageAsync(string senderId, string receiverId, string content)
        {
            _dataContext.Messages.Add(
                new Message()
                {
                    SenderId = senderId,
                    ReceiverId = receiverId,
                    Text = content
                });
            await _dataContext.SaveChangesAsync();
        }

    }
}
