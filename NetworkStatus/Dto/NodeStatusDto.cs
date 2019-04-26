using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Dto
{
    public class NodeStatusDto
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public HardwareStatusModel HardwareStatus { get; set; }
        public Models.NetworkStatusModel Network { get; set; }
        public StorageStatus Storage { get; set; }
        public ICollection<LinuxServiceStatus> Services { get; set; }
    }
}
