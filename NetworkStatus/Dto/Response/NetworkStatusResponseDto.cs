using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Dto.Response
{
    public class NetworkStatusResponseDto
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public string PublicIpAddress { get; set; }
        public bool IsVpn { get; set; }
        public string PrivateIpAddress { get; set; }
        public Decimal DownloadSpeed { get; set; }
        public DateTime DateSent { get; set; }
    }
}
