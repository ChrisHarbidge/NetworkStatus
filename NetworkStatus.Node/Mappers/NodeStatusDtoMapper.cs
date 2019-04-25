using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Dtos;
using NetworkStatus.Node.Status;
using NetworkStatus.Node.Status.Device.Network;
using NetworkStatus.Node.Status.Device.Storage;
using NetworkStatus.Node.Status.Service;
using System.Linq;

namespace NetworkStatus.Node.Mappers
{
    public class NodeStatusDtoMapper
    {
        public NodeStatusDto Map(NodeStatus status, NodeConfiguration configuration)
        {
            return new NodeStatusDto
            {
                Id = configuration.NodeId,
                CpuUsage = (decimal)status.HardwareStatus.CpuStatus.CpuPercentageUsed,
                Network = Map(status.HardwareStatus.NetworkStatus),
                NodeName = status.HardwareStatus.Hostname.Name,
                Storage = Map(status.HardwareStatus.Storage),
                RamUsage = status.HardwareStatus.RamUsage.Used,
                TotalRam = status.HardwareStatus.RamUsage.Total,
                Temperature = (decimal)status.HardwareStatus.Temparature.TemperatureDegreesCelcius(),
                Services = status.ServicesStatus.ToList().Select(service => Map(service)).ToList()
            };
        }

        public NetworkStatusDto Map(NodeNetworkStatus status)
        {
            return new NetworkStatusDto
            {
                DownloadSpeed = (decimal)status.DownloadSpeed.Speed,
                IsVpn = status.ExternalStatus.IsVpn,
                PublicIpAddress = status.ExternalStatus.PublicIpAddress
            };
        }

        public StorageStatusDto Map(StorageStatus status)
        {
            return new StorageStatusDto
            {
                TotalStorageSpaceBytes = status.TotalStorageSpace,
                UsedStorageSpaceBytes = status.UsedStorageSpace
            };
        }

        public ServiceStatusDto Map(LinuxServiceStatus status)
        {
            return new ServiceStatusDto
            {
                ServiceName = status.ServiceName,
                IsRunning = status.IsRunning
            };
        }
    }
}
