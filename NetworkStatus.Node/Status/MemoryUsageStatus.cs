using NetworkStatus.Node.Dtos;
using System.IO;
using System.Linq;
using System;

namespace NetworkStatus.Node.Status
{
    class MemoryUsageStatus
    {

        public RamUsageDto GetRamUsage()
        {

            var memInfo = File.ReadAllLines("/proc/meminfo").ToList();


            throw new Exception();
        }
    }
}
