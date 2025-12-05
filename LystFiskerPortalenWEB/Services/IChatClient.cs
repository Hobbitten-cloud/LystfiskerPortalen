using Microsoft.AspNetCore.Components;

namespace LystFiskerPortalenWEB.Services
{
    public interface IChatClient
    {
        Task InitializeAsync(NavigationManager nav);
        void OnMessageReceived(Action<string, string> handler);
        Task SendMessage(string fromId, string toId, string message);
    }
}