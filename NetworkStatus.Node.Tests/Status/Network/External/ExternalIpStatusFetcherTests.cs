﻿using NetworkStatus.Node.Status.Network.External;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
