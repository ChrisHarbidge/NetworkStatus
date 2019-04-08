using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NordVpnParser
{
    class Parser
    {
        private const string FolderPath = @"C:\Users\cjhar\Downloads\ovpn_udp";
        private const string OutputFilePath = @"C:\Users\cjhar\Downloads\NordVpnUdpIpAddresses.txt";
        public void ParseAndWrite()
        {
            var result = new List<string>();

            Directory.EnumerateFiles(FolderPath).ToList().ForEach(filePath =>
            {

                var ipAddress = File.ReadAllLines(filePath).ToList().First(line => line.Contains("remote")).Split(" ")[1];

                Console.WriteLine($"{ipAddress}");

                result.Add(ipAddress);

            });

            File.WriteAllLines(OutputFilePath, result.ToArray());
        }
    }
}
