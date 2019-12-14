using NetworkStatus.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetworkStatus.Persistence.Repositories
{
    public interface IStorageStatusRepository
    {
        Task<ICollection<StorageStatus>> Index();

        Task<ICollection<StorageStatus>> GetStorageStatusesForNode(int NodeId);

        Task AddStorageStatus(StorageStatus storageStatus, int NodeId);
    }
}
