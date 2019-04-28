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
        public HardwareStatusDto HardwareStatus { get; set; }
        public NetworkStatusDto Network { get; set; }
        public StorageStatusDto Storage { get; set; }
        public ICollection<LinuxServiceStatusDto> Services { get; set; }
    }
}
