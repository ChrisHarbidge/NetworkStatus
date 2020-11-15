using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Device.Cpu;
using NetworkStatus.Node.Status.Device.MachineName;
using NetworkStatus.Node.Status.Device.Memory;
using NetworkStatus.Node.Status.Device.Network;
using NetworkStatus.Node.Status.Device.Storage;
using NetworkStatus.Node.Status.Device.Temperature;
using NetworkStatus.Node.Status.Service;
using NetworkStatus.Node.Status.Service.PiHole;
using NetworkStatus.Node.Status.Service.Plex;
using NetworkStatus.Node.Status.Service.Transmission;

namespace NetworkStatus.Node
{
    public class Startup
    {
        public ServiceProvider GetServiceProvider()
        {
            var serviceCollection  = new ServiceCollection();
            
            RegisterServices(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }

        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStatusFetcher, StatusFetcher>()
                .AddSingleton<INodeMachineNameService, NodeMachineNameService>()
                .AddSingleton<INetworkStatusService, NetworkStatusService>()
                .AddSingleton<IHardwareStatusService, HardwareStatusService>()
                .AddSingleton<IHardwareTemperatureService, HardwareTemperatureService>()
                .AddSingleton<IStorageSpaceService, StorageSpaceService>();
            
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (isWindows)
            {
                serviceCollection.AddSingleton<ICpuStatusService, WindowsCpuStatusService>()
                    .AddSingleton<IMemoryUsageStatusService, WindowsMemoryUsageStatusService>();
            }
            else
            {
                serviceCollection.AddSingleton<ICpuStatusService, LinuxCpuStatusService>()
                    .AddSingleton<IMemoryUsageStatusService, LinuxMemoryUsageStatusService>()
                    .AddSingleton<ILinuxServiceStatusFetcher, LinuxServiceStatusFetcher>()
                    .AddSingleton<IInstalledServiceVerifier, InstalledServiceVerifier>()
                    .AddSingleton<ILinuxService, PiHoleService>()
                    .AddSingleton<ILinuxService, PlexMediaServerService>()
                    .AddSingleton<ILinuxService, TransmissionService>();
            }
        }
    }
}
