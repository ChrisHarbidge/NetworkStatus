using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Mappers;
using NetworkStatus.Node.Status;
using Newtonsoft.Json;

namespace NetworkStatus.Node.Serialisation
{
    class NodeStatusSerialiser
    {
        private NodeStatusDtoMapper _mapper = new NodeStatusDtoMapper();

        private readonly NodeConfiguration _configuration;

        public NodeStatusSerialiser(NodeConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string Serialise(NodeStatus status)
        {
            var mapped = _mapper.Map(status, _configuration);

            return JsonConvert.SerializeObject(mapped);
        }
    }
}
