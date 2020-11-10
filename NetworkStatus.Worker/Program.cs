using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetworkStatus.Worker.Listener;
using NetworkStatus.Worker.Publisher;
using NetworkStatus.Worker.Status;

namespace NetworkStatus.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ServerWorker>()
                        .AddHostedService<ClientWorker>()
                        .AddHostedService<StatusWorker>()
                        .AddSingleton<IExternalNodesBank, ExternalNodesBank>()
                        .AddSingleton<IPublishClient, PublishClient>()
                        .AddSingleton<IListenerServer, ListenerServer>()
                        .AddLogging();
                });
    }
}