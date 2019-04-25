namespace NetworkStatus.Node.Status.Device.Memory
{
    public class RamUsage
    {
        public uint Total { get; set; }
        public uint Free { get; set; }

        public uint Used
        {
            get
            {
                return Total - Free;
            }
        }

        public double PercentageUsed
        {
            get
            {
                return Used * 1.0 / Total * 100;
            }
        }

        public override string ToString()
        {
            return $"Free: {Free} Total: {Total} Used: {Used} PercentageUsed: {PercentageUsed}";
        }
    }
}
