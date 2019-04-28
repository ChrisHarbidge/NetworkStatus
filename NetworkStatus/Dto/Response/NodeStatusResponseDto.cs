using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Dto.Response
{
    public class NodeStatusResponseDto
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public ICollection<HardwareStatusResponseDto> HardwareStatus { get; set; }
        public ICollection<NetworkStatusResponseDto> Network { get; set; }
        public ICollection<StorageStatusResponseDto> Storage { get; set; }
        public ICollection<LinuxServiceStatusResponseDto> Services { get; set; }
    }
}
