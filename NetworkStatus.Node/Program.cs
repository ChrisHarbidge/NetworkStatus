using NetworkStatus.Node.Status;
using System;

namespace NetworkStatus.Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var cpuStatus = new CpuStatus();

            Console.WriteLine($"Cpu usage: {cpuStatus.CurrentCpuUsage()}");

            Console.ReadLine();


        }
    }
}
