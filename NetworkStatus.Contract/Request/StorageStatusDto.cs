using System;

namespace NetworkStatus.Contract.Request
{
    public class StorageStatusDto
    {
        public int NodeId { get; set; }
        public long UsedStorageSpaceBytes { get; set; }
        public long TotalStorageSpaceBytes { get; set; }
        public DateTime DateSent { get; set; }
    }
}
