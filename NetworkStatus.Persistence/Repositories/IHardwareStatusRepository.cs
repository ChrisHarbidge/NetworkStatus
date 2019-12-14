using NetworkStatus.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetworkStatus.Persistence.Repositories
{
    public interface IHardwareStatusRepository
    {
        Task<ICollection<HardwareStatusModel>> Index();

        Task<ICollection<HardwareStatusModel>> GetHardwareStatusesForNode(int nodeId);

        Task AddHardwareStatus(HardwareStatusModel hardwareStatus, int NodeId);
    }
}
