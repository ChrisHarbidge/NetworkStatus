using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkStatus.Models
{
    public class StorageStatus
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NodeId { get; set; }
        public NodeStatus Node { get; set; }

        public long UsedStorageSpaceBytes { get; set; }
        public long TotalStorageSpaceBytes { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateSent { get; set; }
    }
}
