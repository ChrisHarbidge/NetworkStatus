using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Dto
{
    public class LinuxServiceStatusDto
    {
        public int NodeId { get; set; }
        public string ServiceName { get; set; }
        public bool IsRunning { get; set; }
        public DateTime DateSent { get; set; }
    }
}
