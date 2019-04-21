using System.IO;

namespace NetworkStatus.Node.Status.Device.Cpu
{
    public class CpuStatusService : ICpuStatusService
    {
        private CpuProcStatParser _statusParser = new CpuProcStatParser();

        private const string PROCESS_STATUS_FILEPATH = "/proc/stat";

        public CpuStatus CurrentCpuStatus()
        {
            var processFileLines = File.ReadAllLines(PROCESS_STATUS_FILEPATH);

            var result = _statusParser.CalculateCpuUsagePercentage(processFileLines[0]);

            return new CpuStatus
            {
                CpuPercentageUsed = result
            };
        }
    }
}
