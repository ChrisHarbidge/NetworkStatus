using System;
using System.Diagnostics;

namespace NetworkStatus.Node.Status.Device.Cpu
{
    class CpuStatus
    {
        public double CurrentCpuUsagePercentage()
        {
            var currentProcess = Process.GetCurrentProcess();
            var cpu = currentProcess.TotalProcessorTime;

            var runningTotal = 0.0;

            var allProcesses = Process.GetProcesses();

            var timer = new Stopwatch();

            timer.Start();

            foreach (var process in allProcesses)
            {
                try
                {
                    Console.WriteLine($"{process.ProcessName} {process.TotalProcessorTime}");

                    runningTotal += process.TotalProcessorTime.TotalMilliseconds;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to read process with exception: {ex}");
                }
            }

            timer.Stop();


            var result = runningTotal / timer.ElapsedMilliseconds * 100;


            //Process.GetProcesses().ToList().ForEach(process => 
            //{
            //    Console.WriteLine($"{process.ProcessName} {process.TotalProcessorTime}");

            //    runningTotal += process.TotalProcessorTime.TotalMilliseconds;

            //});

            return result;
        }
    }
}
