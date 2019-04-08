using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetworkStatus.Node.Status.Network.External
{
    class ExternalIpAddressVpnResolver
    {
        private const string VPN_IP_ADDRESS_FILE_PATH = "./Resources/NordVpnIpAddresses.txt";

        private List<string> _ipAddresses = new List<string>();

        public bool IpAddressIsVpn(string ipAddress)
        {
            if (_ipAddresses.Count == 0)
            {
                _ipAddresses = File.ReadAllLines(VPN_IP_ADDRESS_FILE_PATH).ToList();
            }

            return _ipAddresses.Contains(ipAddress);
        }
    }
}
