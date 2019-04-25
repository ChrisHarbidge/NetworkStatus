namespace NetworkStatus.Node.Status.Device.Storage
{
    public class StorageStatus
    {
        public long UsedStorageSpace { get; set; }
        public long TotalStorageSpace { get; set; }

        public long UsedStorageSpaceMegabytes() => UsedStorageSpace / (1024 * 1024);
        public long TotalStorageSpaceMegabytes() => TotalStorageSpace / (1024 * 1024);

        public override string ToString()
        {
            return $"{UsedStorageSpaceMegabytes()}MB / {TotalStorageSpaceMegabytes()}MB";
        }

    }
}
