using NetworkStatus.Node.Status.Network.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Tests.Status.Network.Internal
{
    class InternalIpAddressFetcherTests
    {
        private InternalIpAddressFetcher _fetcher;

        private const string LocalNetworkPrefix = "192.168.0.";

        [SetUp]
        public void SetUp()
        {
            _fetcher = new InternalIpAddressFetcher();
        }

        [Test]
        public void InternalIpAddressFetchesCorrectly()
        {
            var internalIpAddress = _fetcher.GetInternalIpAddress();

            Assert.True(internalIpAddress.IpAddress.Length > 0);
            Assert.True(internalIpAddress.IpAddress.ToString().StartsWith(LocalNetworkPrefix));
        }

    }
}
