using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkStatus.Worker.Listener
{
    public interface IListenerServer
    {
        Task Listen(CancellationToken stoppingToken);
    }

    public class ListenerServer : IListenerServer
    {
        private readonly IExternalNodesBank _externalNodesBank;

        public ListenerServer(IExternalNodesBank externalNodesBank)
        {
            _externalNodesBank = externalNodesBank;
        }
        
        public Task Listen(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            { 
                var server = new UdpClient(8891);
                var responseData = Encoding.ASCII.GetBytes("SomeResponseData");
            
                while (stoppingToken.IsCancellationRequested == false)
                {
                    var clientEp = new IPEndPoint(IPAddress.Any, 0);
                    var clientRequestData = server.Receive(ref clientEp);

                    Console.WriteLine($"Adding {clientEp.Address} to the list of hosts");
                    _externalNodesBank.AddAddress(clientEp.Address);
                    server.Send(responseData, responseData.Length, clientEp);
                }
            
                Console.WriteLine("Shutting down server");    
                server.Dispose();
            }, stoppingToken);
        }
    }
}