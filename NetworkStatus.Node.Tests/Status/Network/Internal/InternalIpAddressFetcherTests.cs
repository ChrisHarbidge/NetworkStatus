using NetworkStatus.Node.Status.Device.Network.Internal;
using NUnit.Framework;

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
