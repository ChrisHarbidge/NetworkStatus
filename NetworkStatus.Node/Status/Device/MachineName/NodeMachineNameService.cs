using System;

namespace NetworkStatus.Node.Status.Device.MachineName
{
    public class NodeMachineNameService : INodeMachineNameService
    {
        public NodeMachineName GetMachineName()
        {
            return new NodeMachineName
            {
                Name = Environment.MachineName
            };
        }
    }
}
