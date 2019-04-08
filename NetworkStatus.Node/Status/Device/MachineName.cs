using System;

namespace NetworkStatus.Node.Status.Device
{
    class MachineName
    {
        public string GetHostName()
        {
            return Environment.MachineName;
        }
    }
}
