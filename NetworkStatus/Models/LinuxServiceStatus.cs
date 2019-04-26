using System;

namespace NetworkStatus.Models
{
    public class LinuxServiceStatus
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public bool IsRunning { get; set; }
        public DateTime DateSent { get; set; }
    }
}
