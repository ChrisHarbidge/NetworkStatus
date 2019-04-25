using System.IO;
using System.Linq;

namespace NetworkStatus.Node.Status.Device.Storage
{
    public class StorageSpaceService : IStorageSpaceService
    {
        private const string ROOT_DRIVE_NAME = "/";

        public StorageStatus GetStorageStatus()
        {
            var rootDrive = DriveInfo.GetDrives().ToList().First(drive => drive.Name == "/");
            return new StorageStatus
            {
                TotalStorageSpace = rootDrive.TotalSize,
                UsedStorageSpace = rootDrive.TotalSize - rootDrive.TotalFreeSpace
            };
        }
    }
}
