using System;
using System.Diagnostics;

namespace NetworkStatus.Node.Status.Device.Cpu
{
    public class WindowsCpuStatusService : ICpuStatusService
    {
        public CpuStatus CurrentCpuStatus()
        {
            var proc = Process.GetCurrentProcess();
            var mem = proc.WorkingSeat64;
            var cpu = proc.TotalProcessorTime;
            Console.WriteLine("My process used working set {0:n3} K of working set and CPU {1:n} msec", mem / 1024.0, cpu.TotalMilliseconds);

            foreach (var aProc in Process.GetProcesses())
                Console.WriteLine("Proc {0,30}  CPU {1,-20:n} msec", aProc.ProcessName, cpu.TotalMilliseconds);
        }
    }
}