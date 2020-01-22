using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetworkStatus.Persistence.Data;
using System;

namespace NetworkStatus.WebApi
{
    public class Program
    {
        //public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();


        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            var services = host.Services;

                try
                {
                    var context = (ApplicationDbContext)services.GetService(typeof(ApplicationDbContext));
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = (ILogger<Program>)services.GetService(typeof(ILogger<Program>));
                    logger.LogError(ex, "An error occurred seeding the database");
                }
            

            host.Run();
        }
    
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
