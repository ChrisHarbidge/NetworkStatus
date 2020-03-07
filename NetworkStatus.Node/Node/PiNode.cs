using NetworkStatus.Contract.Request;
using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Mappers;
using NetworkStatus.Node.Status;
using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Service;
using System;
using System.Collections.Concurrent;
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

        public NodeStatus GetCurrentStatus()
        {

            var hardwareStatus = _hardwareStatusService.GetHardwareStatus();
            var servicesStatuses = new ConcurrentBag<LinuxServiceStatus>();

            Parallel.ForEach(_services, service => {
                try
                {
                    servicesStatuses.Add(_serviceStatusFetcher.ServiceIsRunning(service));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception with service {service.ServiceName()}: {ex.Message}");
                }
            });

            return new NodeStatus
            {
                HardwareStatus = hardwareStatus,
                ServicesStatus = servicesStatuses.ToList()
            };

        }

        public void PrintStatuses()
        {
            Console.WriteLine($"{_hardwareStatusService.GetHardwareStatus().ToString()}");

            Parallel.ForEach(_services, (service) =>
            {
                LinuxServiceStatus serviceStatus = null;

                try
                {
                    serviceStatus = _serviceStatusFetcher.ServiceIsRunning(service);
                    Console.WriteLine($"Service {service.ServiceName()} is running: {serviceStatus.IsRunning}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception with service {service.ServiceName()}: {ex.Message}");
                }
            });
        }
    }
}
