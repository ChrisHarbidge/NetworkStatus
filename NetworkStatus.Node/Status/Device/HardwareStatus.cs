using NetworkStatus.Node.Status.Device.Cpu;
using NetworkStatus.Node.Status.Device.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Device
{
    class HardwareStatus
    {
        private CpuStatus _cpuStatus = new CpuStatus();
        private MachineName _machineName = new MachineName();
        private MemoryUsageStatus _memoryUsageStatus = new MemoryUsageStatus();

        public string GetHardwareStatusString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Machine Name: {_machineName.GetHostName()}");
            stringBuilder.AppendLine($"Cpu usage: {_cpuStatus.CurrentCpuUsagePercentage()}%");
            stringBuilder.AppendLine($"Memory Usage: {_memoryUsageStatus.GetRamUsage().ToString()}%");

            return stringBuilder.ToString();
        }
    }
}
