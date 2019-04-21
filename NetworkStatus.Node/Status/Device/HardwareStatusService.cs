using NetworkStatus.Node.Dtos;
using NetworkStatus.Node.Status.Device.Cpu;
using NetworkStatus.Node.Status.Device.MachineName;
using NetworkStatus.Node.Status.Device.Memory;
using NetworkStatus.Node.Status.Device.Network;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Status.Device
{
    class HardwareStatusService : IHardwareStatusService
    {
        private ICpuStatusService _cpuStatusService;
        private INodeMachineNameService _machineNameService;
        private IMemoryUsageStatusService _memoryUsageStatusService;
        private INetworkStatusService _networkStatusService;

        public HardwareStatusService(ICpuStatusService cpuStatusService, 
            INodeMachineNameService nodeMachineNameService,
            IMemoryUsageStatusService memoryUsageStatusService,
            INetworkStatusService networkStatusService)
        {
            _cpuStatusService = cpuStatusService;
            _machineNameService = nodeMachineNameService;
            _memoryUsageStatusService = memoryUsageStatusService;
            _networkStatusService = networkStatusService;
        }

        public HardwareStatus GetHardwareStatus()
        {
            NodeMachineName machineName = null;
            CpuStatus cpuStatus = null;
            RamUsageDto memoryStatus = null;
            NodeNetworkStatus networkStatus = null;

            Task.WaitAll(new[] {
                Task.Run(() => { machineName = _machineNameService.GetMachineName(); }),
                Task.Run(() => { cpuStatus = _cpuStatusService.CurrentCpuStatus(); }),
                Task.Run(() => { memoryStatus = _memoryUsageStatusService.GetRamUsage(); }),
                Task.Run(() => { networkStatus = _networkStatusService.GetNetworkStatus(); }),
            });


            return new HardwareStatus
            {
                CpuStatus = cpuStatus,
                Hostname = machineName,
                RamUsage = memoryStatus,
                NetworkStatus = networkStatus
            };
        }
    }
}
