using System;
using System.Diagnostics;
using System.IO;

namespace NetworkStatus.Node.Status.Device.Cpu
{
    class CpuStatus
    {
        private CpuProcStatParser _statusParser = new CpuProcStatParser();

        private const string PROCESS_STATUS_FILEPATH = "/proc/stat";

        public double CurrentCpuUsagePercentage()
        {
            var processFileLines = File.ReadAllLines(PROCESS_STATUS_FILEPATH);

            var result = _statusParser.CalculateCpuUsagePercentage(processFileLines[0]);

            return result;
        }
    }
}
