using System.Collections.Generic;

namespace NetworkStatus.Node.Configuration
{
    class NodeConfiguration
    {
        public List<string> ServiceNames { get; set; } = new List<string>();
        public string ServerIpAddress { get; set; }
    }
}
