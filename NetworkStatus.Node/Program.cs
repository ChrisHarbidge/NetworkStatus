using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Node;
using NetworkStatus.Node.Status.Device.Cpu;
using System;
using System.Threading;

namespace NetworkStatus.Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting node monitor...");

            var configManager = new ConfigurationManager();

            var config = configManager.LoadConfiguration();

            var node = new PiNode(config);

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

                Thread.Sleep(10000);
            }

            Console.ReadLine();


        }
    }
}
