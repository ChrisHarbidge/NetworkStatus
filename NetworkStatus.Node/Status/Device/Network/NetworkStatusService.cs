using NetworkStatus.Node.Status.Device.Network.External;
using NetworkStatus.Node.Status.Device.Network.Internal;
using NetworkStatus.Node.Status.Device.Network.Performance;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Device.Network
{
    class NetworkStatusService
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
            return new NodeNetworkStatus
            {
                DownloadSpeed = _downloadSpeedFetcher.GetDownloadSpeedMegabytes().Result,
                ExternalStatus = _externalIpStatusFetcher.FetchExternalStatus().Result,
                InternalpIpStatus = _internalIpAddressFetcher.GetInternalIpAddress()
            };
        }

    }
}
