using NetworkStatus.Node.Status.Device.Cpu;
using NetworkStatus.Node.Status.Device.MachineName;
using NetworkStatus.Node.Status.Device.Memory;
using NetworkStatus.Node.Status.Device.Network;
using NetworkStatus.Node.Status.Device.Storage;
using NetworkStatus.Node.Status.Device.Temperature;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Status.Device
{
    class HardwareStatusService : IHardwareStatusService
    {
        private ICpuStatusService _cpuStatusService;
        private INodeMachineNameService _machineNameService;
        private IMemoryUsageStatusService _memoryUsageStatusService;
        private INetworkStatusService _networkStatusService;
        private IHardwareTemperatureService _hardwareTemperatureService;
        private IStorageSpaceService _storageSpaceService;

        // TODO: Break this down, too many dependencies

        public HardwareStatusService(ICpuStatusService cpuStatusService, 
            INodeMachineNameService nodeMachineNameService,
            IMemoryUsageStatusService memoryUsageStatusService,
            INetworkStatusService networkStatusService,
            IHardwareTemperatureService hardwareTemperatureService,
            IStorageSpaceService storageSpaceService)
        {
            _cpuStatusService = cpuStatusService;
            _machineNameService = nodeMachineNameService;
            _memoryUsageStatusService = memoryUsageStatusService;
            _networkStatusService = networkStatusService;
            _hardwareTemperatureService = hardwareTemperatureService;
            _storageSpaceService = storageSpaceService;
        }

        public HardwareStatus GetHardwareStatus()
        {
            NodeMachineName machineName = null;
            CpuStatus cpuStatus = null;
            RamUsage memoryStatus = null;
            NodeNetworkStatus networkStatus = null;
            HardwareTemperature hardwareTemperature = null;
            StorageStatus storageStatus = null;

            Task.WaitAll(new[] {
                Task.Run(() => { machineName = _machineNameService.GetMachineName(); }),
                Task.Run(() => { cpuStatus = _cpuStatusService.CurrentCpuStatus(); }),
                Task.Run(() => { memoryStatus = _memoryUsageStatusService.GetRamUsage(); }),
                Task.Run(() => { networkStatus = _networkStatusService.GetNetworkStatus(); }),
                Task.Run(() => { hardwareTemperature = _hardwareTemperatureService.GetHardwareTemperature(); }),
                Task.Run(() => { storageStatus = _storageSpaceService.GetStorageStatus(); }),
            });


            return new HardwareStatus
            {
                CpuStatus = cpuStatus,
                Hostname = machineName,
                RamUsage = memoryStatus,
                NetworkStatus = networkStatus,
                Temparature = hardwareTemperature,
                Storage = storageStatus
            };
        }
    }
}
