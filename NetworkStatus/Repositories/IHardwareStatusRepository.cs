using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Repositories
{
    public interface IHardwareStatusRepository
    {
        Task<ICollection<HardwareStatusModel>> Index();

        Task<ICollection<HardwareStatusModel>> GetHardwareStatusesForNode(int nodeId);

        Task AddHardwareStatus(HardwareStatusModel hardwareStatus, int NodeId);
    }
}
