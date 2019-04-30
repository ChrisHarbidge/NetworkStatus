using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Repositories
{
    public interface INodeStatusRepository
    {
        Task<ICollection<NodeStatus>> Index();
        Task<NodeStatus> Get(int nodeId);
        Task AddNodeStatus(NodeStatus status);

        bool NodeStatusExists(int id);
    }
}
