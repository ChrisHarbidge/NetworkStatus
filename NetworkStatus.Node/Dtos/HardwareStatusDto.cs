using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Dtos
{
    public class HardwareStatusDto
    {
        public Decimal Temperature { get; set; }
        public Decimal CpuUsage { get; set; }
        public Decimal RamUsage { get; set; }
        public Decimal TotalRam { get; set; }
    }
}
