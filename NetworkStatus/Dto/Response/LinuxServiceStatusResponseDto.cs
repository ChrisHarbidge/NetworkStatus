using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
