using System;

namespace NetworkStatus.Contract.Response
{
    public class StorageStatusResponseDto
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public long UsedStorageSpaceBytes { get; set; }
        public long TotalStorageSpaceBytes { get; set; }
        public DateTime DateSent { get; set; }
    }
}
