using System.Linq;
using System.Net;

namespace NetworkStatus.Node.Status.Network.Internal
{
    public class InternalIpAddressFetcher
    {
        private const string LocalIpAddressPrefix = "192.168.0.";

        public InternalIpAddress GetInternalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            var internalIpString = host.AddressList.ToList()
                .First((ip) => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && ip.ToString().Contains(LocalIpAddressPrefix))
                .ToString();

            return new InternalIpAddress
            {
                IpAddress = internalIpString
            };
        }
    }
}
