using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        private readonly IEnumerable<ILinuxService> _services;
        private readonly ILinuxServiceStatusFetcher _serviceStatusFetcher;
        private readonly IHardwareStatusService _hardwareStatusService;
        private readonly IInstalledServiceVerifier _installedServiceVerifier;
        private readonly ILogger<IStatusFetcher> _logger;

        public StatusFetcher(ILinuxServiceStatusFetcher serviceStatusFetcher,
            IHardwareStatusService hardwareStatusService, 
            IEnumerable<ILinuxService> services, 
            IInstalledServiceVerifier installedServiceVerifier, 
            ILogger<IStatusFetcher> logger)
        {
            _hardwareStatusService = hardwareStatusService;
            _serviceStatusFetcher = serviceStatusFetcher;
            _services = services;
            _installedServiceVerifier = installedServiceVerifier;
            _logger = logger;
        }

        public NodeStatus GetCurrentStatus()
        {
            var hardwareStatus = _hardwareStatusService.GetHardwareStatus();
            var servicesStatuses = new ConcurrentBag<LinuxServiceStatus>();

            Parallel.ForEach(_services.Where(_installedServiceVerifier.ServiceIsInstalled), service => {
                try
                {
                    servicesStatuses.Add(_serviceStatusFetcher.ServiceIsRunning(service));
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception with service {service.ServiceName()}: {ex.Message}");
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
