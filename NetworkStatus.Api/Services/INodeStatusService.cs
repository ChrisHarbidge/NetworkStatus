using NetworkStatus.Contract.Request;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetworkStatus.Contract.Response;

namespace NetworkStatus.WebApi.Services
{
    public interface INodeStatusService
    {
        Task UpdateNodeStatus(NodeStatusDto nodeStatus);

        Task AddNodeStatus(NodeStatusDto nodeStatus);

        Task<IEnumerable<NodeStatusResponseDto>> Index();
        Task<NodeStatusResponseDto> Get(int nodeId);
        bool Exists(int nodeId);
    }
}
