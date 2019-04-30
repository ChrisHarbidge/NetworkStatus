using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Models
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
