using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkStatus.Dto.Response
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
