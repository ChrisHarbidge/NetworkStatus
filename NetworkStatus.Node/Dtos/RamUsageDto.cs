using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Dtos
{
    public class RamUsageDto
    {
        public uint Total { get; set; }
        public uint Free { get; set; }

        public uint Used {
            get
            {
                return Total - Free;
            }
        }

        public uint PercentageUsed
        {
            get
            {
                return (Used % Total) * 100;
            }
        }
    }
}
