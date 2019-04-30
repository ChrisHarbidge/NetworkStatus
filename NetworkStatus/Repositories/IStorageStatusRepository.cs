using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Repositories
{
    public interface IStorageStatusRepository
    {
        Task<ICollection<StorageStatus>> Index();

        Task<ICollection<StorageStatus>> GetStorageStatusesForNode(int NodeId);

        Task AddStorageStatus(StorageStatus storageStatus, int NodeId);
    }
}
