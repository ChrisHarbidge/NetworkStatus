using NetworkStatus.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetworkStatus.Persistence.Repositories
{
    public interface INetworkStatusRepository
    {
        Task<ICollection<NetworkStatusModel>> Index();
        Task<ICollection<NetworkStatusModel>> GetStatusesForNode(int nodeId);
        Task AddNetworkStatus(NetworkStatusModel networkStatus, int nodeId);
    }
}
