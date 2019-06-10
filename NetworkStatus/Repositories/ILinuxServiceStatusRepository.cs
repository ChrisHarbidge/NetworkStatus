using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Repositories
{
    public interface ILinuxServiceStatusRepository
    {
        Task<ICollection<LinuxServiceStatus>> Index();
        Task<ICollection<LinuxServiceStatus>> GetLinuxServiceStatusesForNode(int nodeId);
        Task<ICollection<LinuxServiceStatus>> GetLatestServiceStatusesForNode(int nodeId);
        Task AddLinuxServiceStatuses(ICollection<LinuxServiceStatus> statuses, int NodeId);
    }
}
