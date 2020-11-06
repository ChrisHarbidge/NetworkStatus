using System.IO;
using System.Linq;
using NetworkStatus.Node.Mappers;

namespace NetworkStatus.Node.Status.Device.Memory
{
    class LinuxMemoryUsageStatusService : IMemoryUsageStatusService
    {
        private RamUsageMapper _mapper = new RamUsageMapper();

        public RamUsage GetRamUsage()
        {
            var memInfo = File.ReadAllLines("/proc/meminfo").ToList();

            return _mapper.Map(memInfo);
        }
    }
}
