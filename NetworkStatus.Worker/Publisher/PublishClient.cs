using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkStatus.Worker.Publisher
{
    public interface IPublishClient
    {
        Task Connect(CancellationToken cancellationToken);
    }

    public class PublishClient : IPublishClient
    {
        public Task Connect(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                // while (cancellationToken.IsCancellationRequested == false)
                // {
                    var client = new UdpClient();
                    var requestData = Encoding.ASCII.GetBytes("SomeRequestData");
                    var serverEp = new IPEndPoint(IPAddress.Any, 0);

                    client.EnableBroadcast = true;
                    client.Send(requestData, requestData.Length, new IPEndPoint(IPAddress.Broadcast, 8891));

                    var serverResponseData = client.Receive(ref serverEp);
                    var serverResponse = Encoding.ASCII.GetString(serverResponseData);
                    Console.WriteLine("Recived {0} from {1}", serverResponse, serverEp.Address.ToString());

                    client.Close();
                // }
            }, cancellationToken);
        }
    }
}