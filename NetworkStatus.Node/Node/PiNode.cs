using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Dtos;
using NetworkStatus.Node.Mappers;
using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Device.Network;
using NetworkStatus.Node.Status.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Node
{
    class PiNode
    {
        private List<ILinuxService> _services = new List<ILinuxService>();

        private readonly NodeConfiguration _configuration;
        private readonly ServiceMapper _serviceMapper = new ServiceMapper();
        private readonly LinuxServiceStatusFetcher _serviceStatusFetcher = new LinuxServiceStatusFetcher();
        private readonly IHardwareStatusService _hardwareStatusService;

        public PiNode(NodeConfiguration configuration, IHardwareStatusService hardwareStatusService)
        {
            _configuration = configuration;
            _services.AddRange(configuration.ServiceNames.Select(_serviceMapper.Resolve));
            _hardwareStatusService = hardwareStatusService;
        }

        public void PrintStatuses()
        {
            Console.WriteLine($"{_hardwareStatusService.GetHardwareStatus().ToString()}");

            Parallel.ForEach(_services, (service) =>
            {
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
