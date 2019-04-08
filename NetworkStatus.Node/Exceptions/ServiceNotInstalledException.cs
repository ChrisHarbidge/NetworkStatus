using System;

namespace NetworkStatus.Node.Exceptions
{
    class ServiceNotInstalledException : Exception
    {
        public ServiceNotInstalledException(string serviceName) : base($"Service not installed on system: {serviceName}")
        { }

    }
}
