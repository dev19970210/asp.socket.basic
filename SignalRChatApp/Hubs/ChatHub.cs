using Microsoft.AspNetCore.SignalR;

namespace SignalRChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string dataURL)
        {
            await Clients.All.SendAsync("ReceiveMessage", dataURL, Context.ConnectionId);
        }
    }
}
