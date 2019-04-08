using System;

namespace NetworkStatus.Node.Exceptions
{
    class UnknownServiceException : Exception
    {

        public UnknownServiceException(string serviceName) : base($"Unknown service: {serviceName}") { }


    }
}
