using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace NetworkStatus.Worker.Listener
{
    public interface IListenerServer
    {
        Task Listen(CancellationToken stoppingToken);
    }

    public class ListenerServer : IListenerServer
    {
        private readonly IExternalNodesBank _externalNodesBank;
        private readonly ILogger<ListenerServer> _logger;

        public ListenerServer(IExternalNodesBank externalNodesBank, ILogger<ListenerServer> logger)
        {
            _externalNodesBank = externalNodesBank;
            _logger = logger;
        }
        
        public Task Listen(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            { 
                using var server = new UdpClient(8893);
                var responseData = Encoding.ASCII.GetBytes("SomeResponseData");
            
                while (stoppingToken.IsCancellationRequested == false)
                {
                    var clientEp = new IPEndPoint(IPAddress.Any, 0);
                    var clientRequestData = server.Receive(ref clientEp);

                    _logger.LogInformation($"Adding {clientEp.Address} to the list of hosts");
                    _externalNodesBank.AddAddress(clientEp.Address);
                    server.Send(responseData, responseData.Length, clientEp);
                }
            
                Console.WriteLine("Shutting down server");    
            }, stoppingToken);
        }
    }
}