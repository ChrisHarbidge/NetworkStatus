using NetworkStatus.Node.Dtos;
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
            var memTotalLine = outputLines.First(line => line.Contains(TotalMemoryKey));

            var totalMemory = ParseKilabytesValue(memTotalLine);

            var freeMemoryLine = outputLines.First(line => line.Contains(FreeMemoryKey));

            var freeMemory = ParseKilabytesValue(freeMemoryLine);

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
