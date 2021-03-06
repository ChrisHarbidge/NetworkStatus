﻿using NetworkStatus.Node.Status.Device.Network.Performance;
using NUnit.Framework;

namespace NetworkStatus.Node.Tests.Status.Network.Performance
{
    class DownloadSpeedFetcherTests
    {
        private DownloadSpeedFetcher _speedFetcher;

        [SetUp]
        public void SetUp()
        {
            _speedFetcher = new DownloadSpeedFetcher();
        }

        [Test]
        public void SpeedFetcherFetches()
        {
            var result = _speedFetcher.GetDownloadSpeedMegabytes().Result;

            Assert.True(result.Speed > 0);
        }
    }
}
