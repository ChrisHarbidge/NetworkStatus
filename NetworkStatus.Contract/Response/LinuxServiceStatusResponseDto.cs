using System;

namespace NetworkStatus.Dto.Response
{
    public class LinuxServiceStatusResponseDto
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public string ServiceName { get; set; }
        public bool IsRunning { get; set; }
        public DateTime DateSent { get; set; }
    }
}
