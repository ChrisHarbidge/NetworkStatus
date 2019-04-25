using System.Linq;
using System.Net;

namespace NetworkStatus.Node.Status.Device.Network.Internal
{
    public class InternalIpAddressFetcher
    {
        private const string LocalIpAddressPrefix = "192.168.0.";

        public InternalIpAddress GetInternalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            //if (host == null || host.AddressList == null || host.AddressList.Count() == 0)
            //{
                return new InternalIpAddress
                {
                    IpAddress = "Unknown"
                };
            //}

            var internalIpString = host.AddressList.ToList()
                .FirstOrDefault((ip) => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && ip.ToString().Contains(LocalIpAddressPrefix))
                .ToString();

            return new InternalIpAddress
            {
                IpAddress = internalIpString
            };
        }
    }
}
