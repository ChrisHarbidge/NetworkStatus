using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Dtos;
using NetworkStatus.Node.Mappers;
using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Device.Network;
using NetworkStatus.Node.Status.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkStatus.Node.Node
{
    class PiNode
    {
        private List<ILinuxService> _services = new List<ILinuxService>();

        private readonly NodeConfiguration _configuration;
        private readonly ServiceMapper _serviceMapper = new ServiceMapper();
        private readonly LinuxServiceStatusFetcher _serviceStatusFetcher = new LinuxServiceStatusFetcher();
        private readonly HardwareStatus _hardwareStatus = new HardwareStatus();
        private readonly NetworkStatusService _networkStatusService = new NetworkStatusService();

        public PiNode(NodeConfiguration configuration)
        {
            _services.AddRange(configuration.ServiceNames.Select(_serviceMapper.Resolve));
        }

        public void PrintStatuses()
        {
            Console.WriteLine($"{_hardwareStatus.GetHardwareStatusString()}");

            Console.WriteLine($"{_networkStatusService.GetNetworkStatus().ToString()}");

            _services.ForEach(service => {

                var isRunning = false;

                try
                {
                    isRunning = _serviceStatusFetcher.ServiceIsRunning(service);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.WriteLine($"Service {service.ServiceName()} is running: {isRunning}");
                
            });
        }

        public List<NodeStatusDto> GetServiceStatuses()
        {
            _services.Select(_serviceStatusFetcher.ServiceIsRunning);

            throw new NotImplementedException();
        }
    }
}
