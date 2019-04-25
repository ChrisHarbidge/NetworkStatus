namespace NetworkStatus.Node.Status.Device.Memory
{
    interface IMemoryUsageStatusService
    {
        RamUsage GetRamUsage();
    }
}
