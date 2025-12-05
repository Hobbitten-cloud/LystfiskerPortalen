using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace LystFiskerPortalenWEB.Services
{
    public class ChatClient : IChatClient
    {
        public HubConnection? Connection;

        public async Task InitializeAsync(NavigationManager nav)
        {
            Connection = new HubConnectionBuilder()
                .WithUrl(nav.ToAbsoluteUri("/chathub"))
                .WithAutomaticReconnect()
                .Build();

            await Connection.StartAsync();
        }

        public Task SendMessage(string fromId, string toId, string message)
            => Connection!.InvokeAsync("SendMessage", fromId, toId, message);

        public void OnMessageReceived(Action<string, string> handler)
            => Connection!.On("ReceiveMessage", handler);
    }
}
