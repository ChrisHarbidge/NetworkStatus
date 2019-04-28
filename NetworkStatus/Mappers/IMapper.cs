using NetworkStatus.Dto;
using NetworkStatus.Dto.Response;
using NetworkStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Mappers
{
    public interface IMapper
    {
        NodeStatus Map(NodeStatusDto status);
        NodeStatusResponseDto Map(NodeStatus status);
        HardwareStatusModel Map(HardwareStatusDto status);
        HardwareStatusResponseDto Map(HardwareStatusModel status);
        LinuxServiceStatus Map(LinuxServiceStatusDto status);
        LinuxServiceStatusResponseDto Map(LinuxServiceStatus status);
        NetworkStatusModel Map(NetworkStatusDto status);
        NetworkStatusResponseDto Map(NetworkStatusModel status);
        StorageStatus Map(StorageStatusDto status);
        StorageStatusResponseDto Map(StorageStatus status);
    }
}
