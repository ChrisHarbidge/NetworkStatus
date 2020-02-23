using System.Threading.Tasks;

namespace NetworkStatus.Node.Status.Device.Network.External
{
    public class ExternalIpStatusFetcher
    {
        private readonly ExternalIpAddressFetcher _externalIPAddressFetcher;
        private readonly ExternalIpAddressVpnResolver _vpnResolver;

        public ExternalIpStatusFetcher()
        {
            _externalIPAddressFetcher = new ExternalIpAddressFetcher();
            _vpnResolver = new ExternalIpAddressVpnResolver();
        }

        public async Task<ExternalIPStatus> FetchExternalStatus()
        {
            var externalAddress = _externalIPAddressFetcher.FetchExternalIPAddress().Result;
            var isVpn = _vpnResolver.IpAddressIsVpn(externalAddress);
            var result = new ExternalIPStatus
            {
                IsVpn = isVpn,
                PublicIpAddress = externalAddress
            };

            return await Task.FromResult(result).ConfigureAwait(false);
        }
    }
}
