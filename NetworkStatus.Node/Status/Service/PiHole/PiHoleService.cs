using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Service.PiHole
{
    class PiHoleService : ILinuxService
    {
        public string ProcessIdFileName() => "pihold-FTL.ping";

        public string ProcessIdFolder() => "/var/run";

        public string ServiceName() => "PiHole";
    }
}
