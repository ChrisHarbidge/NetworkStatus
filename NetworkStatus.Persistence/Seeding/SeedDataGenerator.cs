using System;
using System.Collections.Generic;
using System.Linq;
using NetworkStatus.Persistence.Models;

namespace NetworkStatus.Persistence.Seeding
{
    public class SeedDataGenerator
    {
        private readonly int _numberToGenerate;
        private readonly Random _random = new Random();

        private const decimal TotalRam = 2147483648;
        private const long TotalStorage = 10737418240;
        
        public SeedDataGenerator(int numberToGenerate)
        {
            _numberToGenerate = numberToGenerate;
        }

        public IEnumerable<HardwareStatusModel> GenerateHardwareStatuses(int nodeId)
        {
            return Enumerable.Range(0, _numberToGenerate).Select(i => new HardwareStatusModel
            {
                Id = i + 1,
                NodeId = nodeId,
                Temperature = new decimal(_random.NextDouble()),
                CpuUsage = new decimal(_random.NextDouble()),
                DateSent = DateTime.Now.AddDays(i),
                RamUsage = new decimal(_random.NextDouble()),
                TotalRam = TotalRam
            }).ToList();
        }

        public IEnumerable<LinuxServiceStatus> GenerateServiceStatuses(int nodeId)
        {
            return Enumerable.Range(0, _numberToGenerate).Select(i => new LinuxServiceStatus
            {
                Id = i + 1,
                DateSent = DateTime.Now.AddDays(i),
                IsRunning = true,
                NodeId = nodeId,
                ServiceName = "TestService"
            }).ToList();
        }

        public IEnumerable<StorageStatus> GenerateStorageStatuses(int nodeId)
        {
            return Enumerable.Range(0, _numberToGenerate).Select(i => new StorageStatus
            {
                Id = i + 1,
                DateSent = DateTime.Now.AddDays(i),
                NodeId = nodeId,
                TotalStorageSpaceBytes = TotalStorage,
                UsedStorageSpaceBytes = _random.Next()
            }).ToList();
        }

        public IEnumerable<NetworkStatusModel> GenerateNetworkStatuses(int nodeId)
        {
            return Enumerable.Range(0, _numberToGenerate).Select(i => new NetworkStatusModel
            {
                Id = i + 1,
                DateSent = DateTime.Now.AddDays(i),
                DownloadSpeed = new decimal(_random.NextDouble()),
                IsVpn = true,
                NodeId = nodeId,
                PrivateIpAddress = "192.168.0.30",
                PublicIpAddress = "1.1.1.1"
            }).ToList();
        }
    }
}