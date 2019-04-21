using NetworkStatus.Node.Status.Device.Cpu;
using NUnit.Framework;

namespace NetworkStatus.Node.Tests.Status.Device.Cpu
{
    class CpuProcParserTests
    {
        private CpuProcStatParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new CpuProcStatParser();
        }

        [Test]
        public void ProcParserParsesCorrectly()
        {
            var line = "cpu  156053021 284825 12810786 1158841647 5804717 0 3170945 0 0 0";

            var result = _parser.CalculateCpuUsagePercentage(line);

            Assert.LessOrEqual(result, 100);
            Assert.GreaterOrEqual(result, 0);

        }

        [Test]
        public void ProcParsesRouglyTenPercentCorrectly()
        {
            var firstLine = "cpu  176178 0 325018 1371388583 369001 0 24532 0 0 0";
            var secondLine = "cpu  176178 0 325019 1371389329 369002 0 24532 0 0 0";

            var firstResult = _parser.CalculateCpuUsagePercentage(firstLine);
            var secondResult = _parser.CalculateCpuUsagePercentage(secondLine);

            Assert.LessOrEqual(secondResult, 100);
        }

    }
}
