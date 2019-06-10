using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Models
{
    public class StatsDashboardModel
    {
        public IEnumerable<HardwareStatusModel> HardwareStatuses { get; set; }
        public IEnumerable<NetworkStatusModel> NetworkStatuses { get; set; }
        public IEnumerable<LinuxServiceStatus> LinuxServiceStatuses { get; set; }
    }
}
