using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Models
{
    public class LinuxServiceStatus
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public bool IsRunning { get; set; }
    }
}
