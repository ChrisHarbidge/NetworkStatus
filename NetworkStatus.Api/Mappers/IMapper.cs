using NetworkStatus.Contract.Request;
using NetworkStatus.Contract.Response;
using NetworkStatus.Persistence.Models;

namespace NetworkStatus.WebApi.Mappers
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
