using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Node;
using NetworkStatus.Node.Status.Device;
using System;
using System.Threading;

namespace NetworkStatus.Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting node monitor...");

            var startup = new Startup();

            var serviceProvider = startup.GetServiceProvider();

            var configManager = new ConfigurationManager();

            var config = configManager.LoadConfiguration();

            var hardwareStatusService = (IHardwareStatusService)serviceProvider.GetService(typeof(IHardwareStatusService));

            var node = new PiNode(config, hardwareStatusService);

            while (true)
            {

                try
                {
                    node.PrintStatuses();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching statuses: {ex}");
                }

                Console.WriteLine($"Sleeping for 10 seconds");

                Console.WriteLine();

                Thread.Sleep(10000);
            }
        }
    }
}
