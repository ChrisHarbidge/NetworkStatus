using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Exceptions
{
    class ReadingUnavailableException : Exception
    {
        public ReadingUnavailableException(string message) : base($"Reading unavailable : {message}")
        {
        }
    }
}
