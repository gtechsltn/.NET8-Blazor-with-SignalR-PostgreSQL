using Microsoft.AspNetCore.SignalR;

namespace WebAppSignalR.Helpers
{
    public class NotificationHub : Hub
    {
        // This method can be called by clients to send messages
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
