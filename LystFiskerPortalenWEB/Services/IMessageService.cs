using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetConversationAsync(string userId1, string userId2);
        Task SaveMessageAsync(string senderId, string receiverId, string content);
    }
}