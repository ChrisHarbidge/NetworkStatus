using NetworkStatus.Node.Dtos;
using NetworkStatus.Node.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetworkStatus.Node.Mappers
{
    public class RamUsageMapper
    {
        private const string TotalMemoryKey = "MemTotal";
        private const string FreeMemoryKey = "MemFree";

        public RamUsageDto Map(List<string> outputLines)
        {
            if (outputLines == null)
            {
                throw new RamUsageReadingException($"Null output lines provided");
            }

            if (outputLines.Count < 2)
            {
                throw new RamUsageReadingException($"Invalid memory usage output from host: {string.Join("\r\n", outputLines.ToArray())}");
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
                var freeMemoryLine = outputLines.First(line => line.Contains(FreeMemoryKey));

                freeMemory = ParseKilabytesValue(freeMemoryLine);
            }
            catch (Exception ex)
            {
                throw new RamUsageReadingException($"Error reading free memory: {ex.Message}");
            }

            return new RamUsageDto
            {
                Free = freeMemory,
                Total = totalMemory
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
    }
}
