using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Dto
{
    public class StorageStatusDto
    {
        public int NodeId { get; set; }
        public long UsedStorageSpaceBytes { get; set; }
        public long TotalStorageSpaceBytes { get; set; }
        public DateTime DateSent { get; set; }
    }
}
