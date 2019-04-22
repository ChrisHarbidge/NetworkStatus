using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Service
{
    class LinuxServicesStatus
    {
        public IEnumerable<LinuxServicesStatus> ServiceStatus { get; set; }
    }
}
