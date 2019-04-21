using System.Collections.Generic;

namespace NetworkStatus.Node.Configuration
{
    class ConfigurationManager
    {
        public NodeConfiguration LoadConfiguration()
        {
            // TODO: Load all of this from a config file
            return new NodeConfiguration
            {
                ServiceNames = new List<string>()
                {
                    "Plex",
                    "Transmission"
                }
            };
        }
    }
}
