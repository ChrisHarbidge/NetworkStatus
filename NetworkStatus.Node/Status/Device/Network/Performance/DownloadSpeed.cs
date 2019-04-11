using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Device.Network.Performance
{
    public class DownloadSpeed
    {
        public double Speed { get; set; }

        public override string ToString()
        {
            return $"{Speed}";
        }
    }
}
