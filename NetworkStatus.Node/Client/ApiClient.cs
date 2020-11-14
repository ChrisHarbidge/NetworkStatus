using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Serialisation;
using NetworkStatus.Node.Status;

namespace NetworkStatus.Node.Client
{
    class ApiClient : IApiClient
    {
        private readonly NodeStatusSerialiser _serialiser;

        private const string EndpointPath = "api/NodeStatus/";

        private readonly HttpClient _client;
        private readonly NodeConfiguration _configuration;

        public ApiClient(HttpClient client, NodeConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
            _serialiser = new NodeStatusSerialiser(configuration);
        }

        public async Task SyncStatusAsync(NodeStatus status)
        {
            // map

            var serialisedStatus = _serialiser.Serialise(status);
            
            var content = new StringContent(serialisedStatus, Encoding.UTF8, "application/json");

            // dispatch

            var fullEndpointPath = EndpointPath + _configuration.NodeId;

            // var fullUrl = Path.Combine(_configuration.ServerAddress, fullEndpointPath);
            //
            // var responseString = await _client.PutAsync(fullUrl, content);
            //
            // Console.WriteLine($"Response: {responseString}");
        }
    }
}
