using System;
using System.Diagnostics;

namespace NetworkStatus.Node.Status.Device.Memory
{
    public class WindowsMemoryUsageStatusService : IMemoryUsageStatusService
    {
        public RamUsage GetRamUsage()
        {
            var output = "";

            var info = new ProcessStartInfo
            {
                FileName = "wmic",
                Arguments = "OS get FreePhysicalMemory,TotalVisibleMemorySize /Value",
                RedirectStandardOutput = true
            };

            using(var process = Process.Start(info))
            {                
                output = process.StandardOutput.ReadToEnd();
            }
 
            var lines = output.Trim().Split("\n");
            var freeMemoryParts = lines[0].Split("=", StringSplitOptions.RemoveEmptyEntries);
            var totalMemoryParts = lines[1].Split("=", StringSplitOptions.RemoveEmptyEntries);
    
            return new RamUsage
            {
                Free = uint.Parse(freeMemoryParts[1])/ 1024,
                Total = uint.Parse(totalMemoryParts[1]) / 1024
            };
        }
    }
}