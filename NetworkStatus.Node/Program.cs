using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Status.Device;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NetworkStatus.Node.Client;

namespace NetworkStatus.Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting node monitor...");

            var startup = new Startup();

            var serviceProvider = startup.GetServiceProvider();

            var configManager = new NodeConfigurationManager();

            var config = configManager.LoadConfiguration();

            var node = serviceProvider.GetService<IStatusFetcher>();

            var httpClient = new HttpClient();

            var apiClient = new ApiClient(httpClient, config);

            while (true)
            {
                var status = node.GetCurrentStatus();

                Console.WriteLine(status.ToString());

                Task.WaitAll(apiClient.SyncStatusAsync(status));

                Console.WriteLine($"Sleeping for 10 seconds");

                Console.WriteLine();

                Thread.Sleep(10000);
            }
        }
    }
}
