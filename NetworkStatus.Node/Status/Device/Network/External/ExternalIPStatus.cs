using System;

namespace NetworkStatus.Node.Status.Device.Network.External
{
    public class ExternalIPStatus
    {
        public string PublicIpAddress { get; set; }
        public bool IsVpn { get; set; }

        public override string ToString()
        {
            return $"Public IP Address: {PublicIpAddress}{Environment.NewLine}" +
                $"Is VPN: {IsVpn}";
        }

    }
}
