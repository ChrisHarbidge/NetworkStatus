using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NetworkStatus.Node.Status;

namespace NetworkStatus.Worker.Client
{
    public interface IApiClient
    {
        Task SendStatus(NodeStatus nodeStatus, IPAddress serverIp);
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;
        private const string EndpointPath = "api/NodeStatus/";
        
        
        public ApiClient(HttpClient client)
        {
            _client = client;
        }
        
        public Task SendStatus(NodeStatus nodeStatus, IPAddress serverIp)
        {
            var fullEndpointPath = EndpointPath + nodeStatus.HardwareStatus.Hostname;
            
            var fullUrl = new Uri($"{serverIp.ToString()}/{fullEndpointPath}");
            
            var stringContent = 
            
            _client.PutAsync(fullUrl, )
            
            throw new System.NotImplementedException();
        }
    }
}