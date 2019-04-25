using System.Collections.Generic;

namespace NetworkStatus.Node.Configuration
{
    public class NodeConfiguration
    {
        public List<string> ServiceNames { get; set; } = new List<string>();
        public string ServerAddress { get; set; }
        public int NodeId { get; set; }
    }
}
