using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace NetworkStatus.Node.Configuration
{
    class NodeConfigurationManager
    {

        private const string CONFIG_FILE_NAME = "NodeConfiguration.json";

        public NodeConfiguration LoadConfiguration()
        {
            if (!File.Exists(CONFIG_FILE_NAME))
                throw new FileNotFoundException(CONFIG_FILE_NAME);

            var config = JsonConvert.DeserializeObject<NodeConfiguration>(File.ReadAllText(CONFIG_FILE_NAME));

            return config;
        }
    }
}
