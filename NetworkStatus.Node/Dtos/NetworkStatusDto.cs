using System;

namespace NetworkStatus.Node.Dtos
{
    public class NetworkStatusDto
    {
        public string PublicIpAddress { get; set; }
        public bool IsVpn { get; set; }
        public string PrivateIpAddress { get; set; }
        public Decimal DownloadSpeed { get; set; }
    }
}
