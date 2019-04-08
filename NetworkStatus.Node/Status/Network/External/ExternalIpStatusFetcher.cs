using System.Threading.Tasks;

namespace NetworkStatus.Node.Status.Network.External
{
    public class ExternalIpStatusFetcher
    {
        private readonly ExternalIPAddressFetcher _externalIPAddressFetcher;
        private readonly ExternalIpAddressVpnResolver _vpnResolver;

        public ExternalIpStatusFetcher()
        {
            _externalIPAddressFetcher = new ExternalIPAddressFetcher();
            _vpnResolver = new ExternalIpAddressVpnResolver();
        }

        public async Task<ExternalIPStatus> FetchExternalStatus()
        {
            return await Task.Run(() =>
            {
                var externalAddress = _externalIPAddressFetcher.FetchExternalIPAddress().Result;
                var isVpn = _vpnResolver.IpAddressIsVpn(externalAddress);

                return new ExternalIPStatus
                {
                    IsVpn = isVpn,
                    PublicIpAddress = externalAddress
                };
            });
        }
    }
}
