using System;
using System.Collections.Generic;

namespace NetworkStatus.Node.Dtos
{
    public class NodeStatusDto
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public HardwareStatusDto HardwareStatus { get; set; }
        public NetworkStatusDto Network { get; set; }
        public StorageStatusDto Storage { get; set; }
        public ICollection<ServiceStatusDto> Services { get; set; }
    }
}
