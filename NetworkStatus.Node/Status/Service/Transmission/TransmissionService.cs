using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Service.Transmission
{
    class TransmissionService : ILinuxService
    {
        public string ProcessIdFileName() => "transmission.pid";

        public string ProcessIdFolder() => "/run/transmission-daemon";

        public string ServiceName() => "Transmission";
    }
}
