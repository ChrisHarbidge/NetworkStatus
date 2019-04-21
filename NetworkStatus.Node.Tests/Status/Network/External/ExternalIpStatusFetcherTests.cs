using NetworkStatus.Node.Status.Device.Network.External;
using NUnit.Framework;

namespace NetworkStatus.Node.Tests.Status.Network.External
{
    class ExternalIpStatusFetcherTests
    {
        private ExternalIpStatusFetcher _externalIpStatusFetcher;

        [SetUp]
        public void SetUp()
        {
            _externalIpStatusFetcher = new ExternalIpStatusFetcher();
        }

        [Test]
        public void ExternalNetworkInfoFetchesCorrectly()
        {
            var externalNetworkInfo = _externalIpStatusFetcher.FetchExternalStatus().Result;

            Assert.IsTrue(externalNetworkInfo.PublicIpAddress.Length > 0);

        }

    }
}
