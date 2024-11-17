using Microsoft.AspNetCore.SignalR;

namespace WebAppSignalR.BgService
{
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.SignalR;
    using WebAppSignalR.Helpers;

    public class NotificationBackgroundService : BackgroundService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationBackgroundService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Your logic to send messages to clients
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Hello from Background Service!", cancellationToken: stoppingToken);

                // Wait for some time before sending another message (for example, every 5 seconds)
                await Task.Delay(5000, stoppingToken);
            }
        }
    }


}
