using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkStatus.Node.Status.Device.Cpu
{
    public class CpuProcStatParser
    {
        //cpu  156053021 284825 12810786 1158841647 5804717 0 3170945 0 0 0

        // https://rosettacode.org/wiki/Linux_CPU_utilization
        // Deltas required for accurate readings, see above


        private const int IDLE_TIME_INDEX = 4;

        private long previousIdleTime = long.MinValue;
        private long previousTotalTime = long.MinValue;

        public double CalculateCpuUsagePercentage(string procFirstLine)
        {
            var split = procFirstLine.Split(" ").ToList();

            var numericalValues = new List<long>();

            split.ForEach(item => {
                if (long.TryParse(item, out long result))
                {
                    numericalValues.Add(result);
                }
            });

            var totalTime = numericalValues.Sum();

            var idleTime = numericalValues.ElementAt(4) * 1.0;

            double percentageSpentIdle = idleTime / totalTime;

            var workingTime = 1 - percentageSpentIdle;

            return workingTime * 100;
        }
    }
}
