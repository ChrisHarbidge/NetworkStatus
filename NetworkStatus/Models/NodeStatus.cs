using System;
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
        public ICollection<HardwareStatusModel> HardwareStatus { get; set; }
        public ICollection<NetworkStatusModel> Network { get; set; }
        public ICollection<StorageStatus> Storage { get; set; }
        public ICollection<LinuxServiceStatus> Services { get; set; }

    }
}
