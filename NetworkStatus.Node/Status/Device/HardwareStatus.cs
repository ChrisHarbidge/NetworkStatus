using NetworkStatus.Node.Dtos;
using NetworkStatus.Node.Status.Device.Cpu;
using NetworkStatus.Node.Status.Device.MachineName;
using NetworkStatus.Node.Status.Device.Network;
using System;
using System.Text;

namespace NetworkStatus.Node.Status.Device
{
    class HardwareStatus
    {
        public CpuStatus CpuStatus { get; set; }
        public NodeMachineName Hostname { get; set; }
        public RamUsageDto RamUsage { get; set; }
        public NodeNetworkStatus NetworkStatus { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Machine Name: {Hostname.Name}");
            stringBuilder.AppendLine($"Cpu usage: {Math.Round(CpuStatus.CpuPercentageUsed, 2)}%");
            stringBuilder.AppendLine($"Memory Usage: {RamUsage.PercentageUsed}%");
            stringBuilder.AppendLine($"Network Status: {NetworkStatus.ToString()}");

            return stringBuilder.ToString();
        }

    }
}


