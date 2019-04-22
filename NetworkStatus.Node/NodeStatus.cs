using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node
{
    class NodeStatus
    {
        public HardwareStatus HardwareStatus { get; set; }
        public LinuxServicesStatus ServicesStatus { get; set; }
    }
}
