using System;

namespace NetworkStatus.Node.Exceptions
{
    public class RamUsageReadingException : Exception
    {
        public RamUsageReadingException(string message) : base($"Ram Usage Reading Error: {message}") { }
    }
}
