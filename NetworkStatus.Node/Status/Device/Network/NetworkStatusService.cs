using NetworkStatus.Node.Status.Device.Network.External;
using NetworkStatus.Node.Status.Device.Network.Internal;
using NetworkStatus.Node.Status.Device.Network.Performance;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Status.Device.Network
{
    class NetworkStatusService : INetworkStatusService
    {
        private readonly DownloadSpeedFetcher _downloadSpeedFetcher;
        private readonly InternalIpAddressFetcher _internalIpAddressFetcher;
        private readonly ExternalIpStatusFetcher _externalIpStatusFetcher;

        public NetworkStatusService()
        {
            _downloadSpeedFetcher = new DownloadSpeedFetcher();
            _internalIpAddressFetcher = new InternalIpAddressFetcher();
            _externalIpStatusFetcher = new ExternalIpStatusFetcher();
        }

        public NodeNetworkStatus GetNetworkStatus()
        {
            DownloadSpeed downloadSpeed = null;
            ExternalIPStatus externalIpStatus = null;
            InternalIpAddress internalIpAddress = null;

            Task.WaitAll(new[] {

                Task.Run(() => { downloadSpeed = _downloadSpeedFetcher.GetDownloadSpeedMegabytes().Result; }),
                Task.Run(() => { externalIpStatus = _externalIpStatusFetcher.FetchExternalStatus().Result; }),

            });

            return new NodeNetworkStatus
            {
                DownloadSpeed = downloadSpeed,
                ExternalStatus = externalIpStatus,
                InternalpIpStatus = internalIpAddress
            };
        }
    }
}
