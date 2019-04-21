using System.Collections.Generic;
using System.Linq;

namespace NetworkStatus.Node.Status.Device.Cpu
{
    public class CpuProcStatParser
    {
        //cpu  156053021 284825 12810786 1158841647 5804717 0 3170945 0 0 0

        // https://rosettacode.org/wiki/Linux_CPU_utilization
        // Deltas required for accurate readings, see above


        private const int IDLE_TIME_INDEX = 3;

        private double previousIdleTime = 0.0;
        private long previousTotalTime = 0;

        public  double CalculateCpuUsagePercentage(string procFirstLine)
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
           

            var idleTime = numericalValues.ElementAt(IDLE_TIME_INDEX) * 1.0;
            
            double percentageSpentIdle = (idleTime - previousIdleTime) / (totalTime - previousTotalTime);

            previousTotalTime = totalTime;
            previousIdleTime = idleTime;

            var workingTime = 1 - percentageSpentIdle;

            return workingTime * 100;
        }
    }
}
