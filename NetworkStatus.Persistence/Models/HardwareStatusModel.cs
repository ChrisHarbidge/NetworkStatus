using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkStatus.Persistence.Models
{
    public class HardwareStatusModel
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NodeId { get; set; }
        public NodeStatus Node { get; set; }


        public Decimal Temperature { get; set; }
        public Decimal CpuUsage { get; set; }
        public Decimal RamUsage { get; set; }
        public Decimal TotalRam { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateSent { get; set; }
    }
}
