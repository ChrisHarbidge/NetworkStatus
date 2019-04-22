using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Device.Storage
{
    public interface IStorageSpaceService
    {
        StorageStatus GetStorageStatus();
    }
}
