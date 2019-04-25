using System.Collections.Generic;

namespace NetworkStatus.Node.Status.Service
{
    public class LinuxServiceStatus
    {
       public string ServiceName { get; set; }
       public bool IsRunning { get; set; }

        public override string ToString()
        {
            return $"{ServiceName} is running: {IsRunning}";
        }
    }
}
