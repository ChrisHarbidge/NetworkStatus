using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Dtos
{
    class NetworkStatusDto
    {
        public string ExternalIpAddress { get; set; }
        public bool IsVpnAddress { get; set; }
        public string InternalIpAddress { get; set; }
        public decimal DownloadSpeed { get; set; }
        public decimal UploadSpeed { get; set; }
    }
}
