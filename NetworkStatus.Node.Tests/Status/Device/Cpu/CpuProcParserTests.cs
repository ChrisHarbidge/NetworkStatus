using NetworkStatus.Node.Status.Device.Cpu;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
