using System;

namespace NetworkStatus.Contract.Request
{
    public class LinuxServiceStatusDto
    {
        public int NodeId { get; set; }
        public string ServiceName { get; set; }
        public bool IsRunning { get; set; }
        public DateTime DateSent { get; set; }
    }
}
