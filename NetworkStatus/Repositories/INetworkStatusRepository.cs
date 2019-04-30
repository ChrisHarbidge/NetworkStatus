using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Repositories
{
    public interface INetworkStatusRepository
    {
        Task<ICollection<NetworkStatusModel>> Index();
        Task<ICollection<NetworkStatusModel>> GetStatusesForNode(int nodeId);
        Task AddNetworkStatus(NetworkStatusModel networkStatus, int nodeId);
    }
}
