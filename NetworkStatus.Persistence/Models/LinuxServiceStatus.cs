using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkStatus.Persistence.Models
{
    public class LinuxServiceStatus
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NodeId { get; set; }
        public NodeStatus Node { get; set; }

        public string ServiceName { get; set; }
        public bool IsRunning { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateSent { get; set; }
    }
}
