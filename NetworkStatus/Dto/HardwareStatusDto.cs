using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Dto
{
    public class HardwareStatusDto
    {
        public int NodeId { get; set; }
        public Decimal Temperature { get; set; }
        public Decimal CpuUsage { get; set; }
        public Decimal RamUsage { get; set; }
        public Decimal TotalRam { get; set; }
        public DateTime DateSent { get; set; }
    }
}
