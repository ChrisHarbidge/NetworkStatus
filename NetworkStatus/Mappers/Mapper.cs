using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Dto;
using NetworkStatus.Dto.Response;
using NetworkStatus.Models;

namespace NetworkStatus.Mappers
{
    public class Mapper : IMapper
    {
        public NodeStatus Map(NodeStatusDto status)
        {
            throw new NotImplementedException();
        }

        public NodeStatusResponseDto Map(NodeStatus status)
        {
            return new NodeStatusResponseDto
            {
                HardwareStatus = status.HardwareStatus.Select(Map).ToList(),
                Id = status.Id,
                Network = status.Network.Select(Map).ToList(),
                NodeName = status.NodeName,
                Services = status.Services.Select(Map).ToList(),
                Storage = status.Storage.Select(Map).ToList()
            };
        }

        public HardwareStatusModel Map(HardwareStatusDto status)
        {
            return new HardwareStatusModel
            {
                CpuUsage = status.CpuUsage,
                DateSent = status.DateSent,
                NodeId = status.NodeId,
                RamUsage = status.RamUsage,
                Temperature = status.Temperature,
                TotalRam = status.TotalRam
            };
        }

        public LinuxServiceStatus Map(LinuxServiceStatusDto status)
        {
            return new LinuxServiceStatus
            {
                DateSent = status.DateSent,
                IsRunning = status.IsRunning,
                NodeId = status.NodeId,
                ServiceName = status.ServiceName
            };
        }

        public NetworkStatusModel Map(NetworkStatusDto status)
        {
            return new NetworkStatusModel
            {
                DateSent = status.DateSent,
                DownloadSpeed = status.DownloadSpeed,
                IsVpn = status.IsVpn,
                NodeId = status.NodeId,
                PrivateIpAddress = status.PrivateIpAddress,
                PublicIpAddress = status.PublicIpAddress
            };
        }

        public StorageStatus Map(StorageStatusDto status)
        {
            return new StorageStatus
            {
                DateSent = status.DateSent,
                NodeId = status.NodeId,
                TotalStorageSpaceBytes = status.TotalStorageSpaceBytes,
                UsedStorageSpaceBytes = status.UsedStorageSpaceBytes
            };
        }

        public HardwareStatusResponseDto Map(HardwareStatusModel status)
        {
            return new HardwareStatusResponseDto
            {
                CpuUsage = status.CpuUsage,
                DateSent = status.DateSent,
                NodeId = status.NodeId,
                RamUsage = status.RamUsage,
                TotalRam = status.TotalRam
            };
        }

        public LinuxServiceStatusResponseDto Map(LinuxServiceStatus status)
        {
            return new LinuxServiceStatusResponseDto
            {
                DateSent = status.DateSent,
                IsRunning = status.IsRunning,
                NodeId = status.NodeId,
                ServiceName = status.ServiceName
            };
        }

        public NetworkStatusResponseDto Map(NetworkStatusModel status)
        {
            return new NetworkStatusResponseDto
            {
                DateSent = status.DateSent,
                DownloadSpeed = status.DownloadSpeed,
                IsVpn = status.IsVpn,
                NodeId = status.NodeId,
                PrivateIpAddress = status.PrivateIpAddress,
                PublicIpAddress = status.PublicIpAddress
            };
        }

        public StorageStatusResponseDto Map(StorageStatus status)
        {
            return new StorageStatusResponseDto
            {
                DateSent = status.DateSent,
                NodeId = status.NodeId,
                TotalStorageSpaceBytes = status.TotalStorageSpaceBytes,
                UsedStorageSpaceBytes = status.UsedStorageSpaceBytes
            };
        }
    }
}
