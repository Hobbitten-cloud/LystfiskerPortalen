using LystFiskerPortalenWEB.Models;
using LystFiskerPortalenWEB.Repo;
using Microsoft.AspNetCore.SignalR;
using LystFiskerPortalenWEB.Services;
using Microsoft.AspNetCore.Authorization;

namespace LystFiskerPortalenWEB.Hubs
{
    
    public class ChatHub : Hub
    {
        private IMessageService _messages;
        
        public ChatHub(IMessageService messages)
        {
            _messages = messages;
        }
        public async Task SendMessage(string senderId, string receiverId,string content)
        {
            await _messages.SaveMessageAsync(senderId, receiverId, content);
            await Clients.User(receiverId)
                .SendAsync("ReceiveMessage", senderId, receiverId);        
        }
    }
}
