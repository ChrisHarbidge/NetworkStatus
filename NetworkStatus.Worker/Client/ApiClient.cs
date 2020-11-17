using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NetworkStatus.Node.Mappers;
using NetworkStatus.Node.Status;
using Newtonsoft.Json;

namespace NetworkStatus.Worker.Client
{
    public interface IApiClient
    {
        Task SendStatus(NodeStatus nodeStatus, IPAddress serverIp);
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;
        // TODO: Port discovery could take place as part of UDP
        private const string EndpointPath = ":5001/api/NodeStatus/";
        private readonly ILogger<IApiClient> _logger;

        public ApiClient(HttpClient client, ILogger<IApiClient> logger)
        {
            _client = client;
            _logger = logger;
        }
        
        public async Task SendStatus(NodeStatus nodeStatus, IPAddress serverIp)
        {
            // TODO: Injection
            var mapper = new NodeStatusDtoMapper();

            var fullEndpointPath = EndpointPath + nodeStatus.HardwareStatus.Hostname.Name;

            // var urlString = $"https://{serverIp.ToString()}{fullEndpointPath}";
            var urlString = $"https://127.0.0.1{fullEndpointPath}";
            
            _logger.LogInformation($"Pushing to {urlString}");

            var fullUrl = new Uri(urlString);

            var nodeStatusDto = mapper.Map(nodeStatus);

            var stringContent = new StringContent(JsonConvert.SerializeObject(nodeStatusDto), Encoding.UTF8, "application/json");

            await _client.PutAsync(fullUrl, stringContent);
        }
    }
}