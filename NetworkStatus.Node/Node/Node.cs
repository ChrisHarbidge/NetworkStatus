using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Dtos;
using NetworkStatus.Node.Mappers;
using NetworkStatus.Node.Status.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkStatus.Node.Node
{
    class Node
    {
        private List<ILinuxService> _services = new List<ILinuxService>();

        private readonly NodeConfiguration _configuration;
        private readonly ServiceMapper _serviceMapper = new ServiceMapper();
        private readonly LinuxServiceStatusFetcher _serviceStatusFetcher = new LinuxServiceStatusFetcher();

        public Node(NodeConfiguration configuration)
        {
            _services.AddRange(configuration.ServiceNames.Select(_serviceMapper.Resolve));
        }

        public List<NodeStatusDto> GetServiceStatuses()
        {
            _services.Select(_serviceStatusFetcher.ServiceIsRunning);

            throw new NotImplementedException();
        }
    }
}
