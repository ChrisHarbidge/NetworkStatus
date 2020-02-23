using System;

namespace NetworkStatus.Contract.Request
{
    public class NetworkStatusDto
    {
        public int NodeId { get; set; }
        public string PublicIpAddress { get; set; }
        public bool IsVpn { get; set; }
        public string PrivateIpAddress { get; set; }
        public decimal DownloadSpeed { get; set; }
        public DateTime DateSent { get; set; }
    }
}
