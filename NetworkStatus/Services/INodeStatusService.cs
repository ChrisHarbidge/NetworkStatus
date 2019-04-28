using NetworkStatus.Dto;
using NetworkStatus.Dto.Response;
using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Services
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
