﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NetworkStatus.Models
{
    public class NodeStatus
    {
        public int Id { get; set; }
        public string NodeName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastPinged { get; set; }

        public Decimal Temperature { get; set; }
        public Decimal CpuUsage { get; set; }
        public Decimal RamUsage { get; set; }
        public Decimal TotalRam { get; set; }
        public NetworkStatus Network { get; set; }
        public StorageStatus Storage { get; set; }
        public ICollection<LinuxServiceStatus> Services { get; set; }

    }
}
