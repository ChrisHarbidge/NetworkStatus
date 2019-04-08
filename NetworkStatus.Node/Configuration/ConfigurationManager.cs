using System.Collections.Generic;

namespace NetworkStatus.Node.Configuration
{
    class ConfigurationManager
    {
        public NodeConfiguration LoadConfiguration()
        {
            return new NodeConfiguration
            {
                ServiceNames = new List<string>()
                {
                    "Plex"
                }
            };
        }
    }
}
