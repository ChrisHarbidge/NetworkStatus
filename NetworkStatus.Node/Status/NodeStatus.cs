using NetworkStatus.Node.Status.Device;
using NetworkStatus.Node.Status.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkStatus.Node.Status
{
    public class NodeStatus
    {
        public HardwareStatus HardwareStatus { get; set; }
        public ICollection<LinuxServiceStatus> ServicesStatus { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(HardwareStatus.ToString());
            ServicesStatus.ToList().ForEach(status =>
            {
                stringBuilder.AppendLine(status.ToString());
            });

            return stringBuilder.ToString();
        }
    }
}
