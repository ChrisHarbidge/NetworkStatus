using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetworkStatus.Node;
using NetworkStatus.Node.Configuration;
using NetworkStatus.Worker.Client;
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
                        .AddSingleton<IApiClient, ApiClient>()
                        .AddSingleton<NodeConfiguration>(new NodeConfiguration())
                        // TODO Factory approach
                        .AddSingleton(new HttpClient())
                        .AddLogging();
                    
                    // Register Node services
                    Startup.RegisterServices(services);
                });
    }
}