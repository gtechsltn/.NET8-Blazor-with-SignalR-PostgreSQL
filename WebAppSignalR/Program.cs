using Microsoft.AspNetCore.Hosting;
using WebAppSignalR.BgService;
using WebAppSignalR.Helpers;

namespace WebAppSignalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register the custom background service
            builder.Services.AddHostedService<NotificationBackgroundService>();
            builder.Services.AddSignalR();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            //app.MapControllers();
            // Map the SignalR hub to the "/notificationHub" URL
            app.MapHub<NotificationHub>("/notificationHub"); // Map the SignalR Hub

            app.Run();
        }
    }
}
