﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Network.Internal
{
    public class InternalIpAddress
    {
        public string IpAddress { get; set; }

        public override string ToString()
        {
            return $"Internal Ip Address: {IpAddress}";
        }
    }
}
