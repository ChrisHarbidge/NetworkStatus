using NetworkStatus.Node.Exceptions;
using NetworkStatus.Node.Status.Service;
using NetworkStatus.Node.Status.Service.Plex;
using System.Collections.Generic;

namespace NetworkStatus.Node.Mappers
{
    class ServiceMapper
    {
        private Dictionary<string, ILinuxService> _serviceMap = new Dictionary<string, ILinuxService>
        {
            { "plex" , new PlexMediaServerService() }
        };

        public ILinuxService Resolve(string serviceName)
        {
            if (_serviceMap.TryGetValue(serviceName, out var service))
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
