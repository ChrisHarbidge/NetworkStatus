using NetworkStatus.Node.Exceptions;
using NetworkStatus.Node.Status.Device.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetworkStatus.Node.Mappers
{
    public class RamUsageMapper
    {
        // Total free memory can be calculated using the sum of these values
        private  string[] FreeMemoryKeys = new string[] {
            "MemFree",
            "Active(file)",
            "Inactive(file)",
            "SReclaimable"
        };

        private const string TotalMemoryKey = "MemTotal";

        public RamUsage Map(List<string> outputLines)
        {
            if (outputLines == null)
            {
                throw new RamUsageReadingException($"Null output lines provided");
            }

            if (outputLines.Count < 2)
            {
                throw new RamUsageReadingException($"Invalid memory usage output from host: {string.Join(Environment.NewLine, outputLines.ToArray())}");
            }

            uint totalMemory;
            uint freeMemory;

            try
            {
                var memTotalLine = outputLines.First(line => line.Contains(TotalMemoryKey));

                totalMemory = ParseKilabytesValue(memTotalLine);
            }
            catch (Exception ex)
            {
                throw new RamUsageReadingException($"Error reading total memory: {ex.Message}");
            }


            try
            {

                freeMemory = 0;

                foreach (string freeKey in FreeMemoryKeys)
                {
                    var freeMemoryLine = outputLines.First(line => line.Contains(freeKey));

                    freeMemory += ParseKilabytesValue(freeMemoryLine);
                }
            }
            catch (Exception ex)
            {
                throw new RamUsageReadingException($"Error reading free memory: {ex.Message}");
            }

            return new RamUsage
            {
                Free = ToMegaBytes(freeMemory),
                Total = ToMegaBytes(totalMemory)
            };
        }


        private uint ParseKilabytesValue(string memoryLine)
        {
            var stringRepresentation = StripNonNumericCharacters(memoryLine);
            return uint.Parse(stringRepresentation);
        }
        
        private string StripNonNumericCharacters(string stringToStrip)
        {
            return Regex.Match(stringToStrip, @"\d+").Value;
        }

        private uint ToMegaBytes(uint kilabytes)
        {
            return kilabytes / 1024;
        }
    }
}
