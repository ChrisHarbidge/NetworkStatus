using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NetworkStatus.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Data;

namespace NetworkStatus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                    Seeder.Initialise(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the database");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            // Use urls for access to local machine when integrating with external machines
            .UseUrls("http://0.0.0.0:12345", "https://0.0.0.0:44331")
                .UseStartup<Startup>();
    }
}
