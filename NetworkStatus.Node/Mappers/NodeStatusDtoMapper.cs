using NetworkStatus.Contract.Request;
using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Status;
using NetworkStatus.Node.Status.Device;
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
                HardwareStatus = Map(status.HardwareStatus),
                Network = Map(status.HardwareStatus.NetworkStatus),
                NodeName = status.HardwareStatus.Hostname.Name,
                Storage = Map(status.HardwareStatus.Storage),
                
                Services = status.ServicesStatus.Select(service => Map(service)).ToList()
            };
        }

        public HardwareStatusDto Map(HardwareStatus hardwareStatus)
        {
            return new HardwareStatusDto
            {
                CpuUsage = (decimal)hardwareStatus.CpuStatus.CpuPercentageUsed,
                RamUsage = hardwareStatus.RamUsage.Used,
                TotalRam = hardwareStatus.RamUsage.Total,
                Temperature = (decimal)hardwareStatus.Temparature.TemperatureDegreesCelcius(),
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

        public LinuxServiceStatusDto Map(LinuxServiceStatus status)
        {
            return new LinuxServiceStatusDto
            {
                ServiceName = status.ServiceName,
                IsRunning = status.IsRunning
            };
        }
    }
}
