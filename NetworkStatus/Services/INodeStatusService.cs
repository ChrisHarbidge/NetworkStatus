using NetworkStatus.Dto;
using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Services
{
    public interface INodeStatusService
    {
        void UpdateNodeStatus(NodeStatusDto nodeStatus);

        Task<IEnumerable<NodeStatus>> Index();
        Task<NodeStatus> Get(int nodeId);
    }
}
