using NetworkStatus.Node.Status.Device.Cpu;
using NetworkStatus.Node.Status.Device.MachineName;
using NetworkStatus.Node.Status.Device.Memory;
using NetworkStatus.Node.Status.Device.Network;
using NetworkStatus.Node.Status.Device.Storage;
using NetworkStatus.Node.Status.Device.Temperature;
using System;
using System.Text;

namespace NetworkStatus.Node.Status.Device
{
    public class HardwareStatus
    {
        public CpuStatus CpuStatus { get; set; }
        public NodeMachineName Hostname { get; set; }
        public RamUsage RamUsage { get; set; }
        public NodeNetworkStatus NetworkStatus { get; set; }
        public HardwareTemperature Temparature { get; set; }
        public StorageStatus Storage { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(); 
            stringBuilder.AppendLine($"Machine Name: {Hostname.Name}");
            stringBuilder.AppendLine($"Cpu usage: {Math.Round(CpuStatus.CpuPercentageUsed, 2)}%");
            stringBuilder.AppendLine($"Memory Usage: {RamUsage.PercentageUsed}%");
            stringBuilder.AppendLine($"Temperature: {Temparature.TemperatureDegreesCelcius()}C");
            stringBuilder.AppendLine($"Network Status: {NetworkStatus.ToString()}");
            stringBuilder.AppendLine($"Storage: {Storage.ToString()}");

            return stringBuilder.ToString();
        }

    }
}


