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

        // TODO: Move these to their respective repositories
        Task AddNetworkStatus(NetworkStatusModel networkStatus, int NodeId);
        Task AddStorageStatus(StorageStatus storageStatus, int NodeId);
        Task AddHardwareStatus(HardwareStatusModel hardwareStatus, int NodeId);
        Task AddLinuxServiceStatuses(ICollection<LinuxServiceStatus> statuses, int NodeId);
    }
}
