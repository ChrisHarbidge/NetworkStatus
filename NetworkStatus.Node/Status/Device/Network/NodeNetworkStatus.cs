using NetworkStatus.Node.Status.Device.Network.External;
using NetworkStatus.Node.Status.Device.Network.Internal;
using NetworkStatus.Node.Status.Device.Network.Performance;
using System.Text;

namespace NetworkStatus.Node.Status.Device.Network
{
    public class NodeNetworkStatus
    {
        public ExternalIPStatus ExternalStatus { get; set; }
        public InternalIpAddress InternalpIpStatus { get; set; }
        public DownloadSpeed DownloadSpeed { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"External Status: {ExternalStatus.ToString()}");
            //builder.AppendLine($"Internal Status: {InternalpIpStatus.ToString()}");
            builder.AppendLine($"Download Speed: {DownloadSpeed.ToString()}");

            return builder.ToString();
        }
    }
}
