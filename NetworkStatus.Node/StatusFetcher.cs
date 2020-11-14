using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Mappers;
using NetworkStatus.Node.Status;
using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Service;

namespace NetworkStatus.Node
{
    public interface IStatusFetcher
    {
        NodeStatus GetCurrentStatus();
    }

    public class StatusFetcher : IStatusFetcher
    {
        private List<ILinuxService> _services = new List<ILinuxService>();

        private readonly NodeConfiguration _configuration;
        private readonly ServiceMapper _serviceMapper = new ServiceMapper();
        private readonly ILinuxServiceStatusFetcher _serviceStatusFetcher;
        private readonly IHardwareStatusService _hardwareStatusService;

        public StatusFetcher(ILinuxServiceStatusFetcher serviceStatusFetcher, IHardwareStatusService hardwareStatusService)
        {
            // TODO: Move this into a whitelisting service
            // _services.AddRange(configuration.ServiceNames.Select(_serviceMapper.Resolve));
            _hardwareStatusService = hardwareStatusService;
            _serviceStatusFetcher = serviceStatusFetcher;
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
    }
}
