﻿using Microsoft.Extensions.DependencyInjection;
using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Device.Cpu;
using NetworkStatus.Node.Status.Device.MachineName;
using NetworkStatus.Node.Status.Device.Memory;
using NetworkStatus.Node.Status.Device.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node
{
    public class Startup
    {
        public ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddScoped<ICpuStatusService, CpuStatusService>()
                .AddScoped<INodeMachineNameService, NodeMachineNameService>()
                .AddScoped<IMemoryUsageStatusService, MemoryUsageStatusService>()
                .AddScoped<INetworkStatusService, NetworkStatusService>()
                .AddScoped<IHardwareStatusService, HardwareStatusService>()
                .BuildServiceProvider();
        }
    }
}
