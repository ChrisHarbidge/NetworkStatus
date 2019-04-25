using System;
using System.Collections.Generic;

namespace NetworkStatus.Node.Dtos
{
    public class NodeStatusDto
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public Decimal Temperature { get; set; }
        public Decimal CpuUsage { get; set; }
        public Decimal RamUsage { get; set; }
        public Decimal TotalRam { get; set; }
        public NetworkStatusDto Network { get; set; }
        public StorageStatusDto Storage { get; set; }
        public ICollection<ServiceStatusDto> Services { get; set; }
    }
}
