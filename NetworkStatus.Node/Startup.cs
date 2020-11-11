﻿using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Device.Cpu;
using NetworkStatus.Node.Status.Device.MachineName;
using NetworkStatus.Node.Status.Device.Memory;
using NetworkStatus.Node.Status.Device.Network;
using NetworkStatus.Node.Status.Device.Storage;
using NetworkStatus.Node.Status.Device.Temperature;

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
            serviceCollection.AddScoped<INodeMachineNameService, NodeMachineNameService>()
                .AddScoped<INetworkStatusService, NetworkStatusService>()
                .AddScoped<IHardwareStatusService, HardwareStatusService>()
                .AddScoped<IHardwareTemperatureService, HardwareTemperatureService>()
                .AddScoped<IStorageSpaceService, StorageSpaceService>();
            
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (isWindows)
            {
                serviceCollection.AddScoped<ICpuStatusService, WindowsCpuStatusService>()
                    .AddScoped<IMemoryUsageStatusService, WindowsMemoryUsageStatusService>();
            }
            else
            {
                serviceCollection.AddScoped<ICpuStatusService, LinuxCpuStatusService>()
                    .AddScoped<IMemoryUsageStatusService, LinuxMemoryUsageStatusService>();
            }
        }
    }
}
