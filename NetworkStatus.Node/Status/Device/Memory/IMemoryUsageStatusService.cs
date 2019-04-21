using NetworkStatus.Node.Dtos;

namespace NetworkStatus.Node.Status.Device.Memory
{
    interface IMemoryUsageStatusService
    {
        RamUsageDto GetRamUsage();
    }
}
