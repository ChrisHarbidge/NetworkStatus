using NetworkStatus.Node.Exceptions;
using NetworkStatus.Node.Status.Service;
using NetworkStatus.Node.Status.Service.PiHole;
using NetworkStatus.Node.Status.Service.Plex;
using NetworkStatus.Node.Status.Service.Transmission;
using System.Collections.Generic;

namespace NetworkStatus.Node.Mappers
{
    class ServiceMapper
    {
        private Dictionary<string, ILinuxService> _serviceMap = new Dictionary<string, ILinuxService>
        {
            { "plex" , new PlexMediaServerService() },
            { "transmission", new TransmissionService() },
            { "pihole", new PiHoleService() }

        };

        public ILinuxService Resolve(string serviceName)
        {
            if (_serviceMap.TryGetValue(serviceName.ToLower(), out var service))
            {
                return service;
            }
            else
            {
                throw new UnknownServiceException(serviceName);
            }
        }
    }
}
