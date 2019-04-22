using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Models
{
    public class StorageStatus
    {
        public int Id { get; set; }
        public long UsedStorageSpaceBytes { get; set; }
        public long TotalStorageSpaceBytes { get; set; }
    }
}
