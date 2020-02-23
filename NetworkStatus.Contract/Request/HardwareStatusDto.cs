using System;

namespace NetworkStatus.Contract.Request
{
    public class HardwareStatusDto
    {
        public int NodeId { get; set; }
        public decimal Temperature { get; set; }
        public decimal CpuUsage { get; set; }
        public decimal RamUsage { get; set; }
        public decimal TotalRam { get; set; }
        public DateTime DateSent { get; set; }
    }
}
