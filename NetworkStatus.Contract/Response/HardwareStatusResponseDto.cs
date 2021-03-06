﻿using System;

namespace NetworkStatus.Contract.Response
{
    public class HardwareStatusResponseDto
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public Decimal Temperature { get; set; }
        public Decimal CpuUsage { get; set; }
        public Decimal RamUsage { get; set; }
        public Decimal TotalRam { get; set; }
        public DateTime DateSent { get; set; }
    }
}
