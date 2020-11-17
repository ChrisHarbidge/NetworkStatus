using NetworkStatus.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetworkStatus.Persistence.Repositories
{
    public interface INodeStatusRepository
    {
        Task<ICollection<NodeStatus>> Index();
        Task<NodeStatus> Get(int nodeId);
        Task AddNodeStatus(NodeStatus status);

        bool NodeStatusExists(string nodeName);
        int GetId(string nodeName);
    }
}
