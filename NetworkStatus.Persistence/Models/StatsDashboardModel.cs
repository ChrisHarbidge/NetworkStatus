using System.Collections.Generic;

namespace NetworkStatus.Persistence.Models
{
    // TODO: Move this to WebAPI project
    public class StatsDashboardModel
    {
        public IEnumerable<HardwareStatusModel> HardwareStatuses { get; set; }
        public IEnumerable<NetworkStatusModel> NetworkStatuses { get; set; }
        public IEnumerable<LinuxServiceStatus> LinuxServiceStatuses { get; set; }
    }
}
