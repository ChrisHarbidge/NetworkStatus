namespace NetworkStatus.Node.Status.Device.Network.Internal
{
    public class InternalIpAddress
    {
        public string IpAddress { get; set; }

        public override string ToString()
        {
            return $"Internal Ip Address: {IpAddress}";
        }
    }
}
