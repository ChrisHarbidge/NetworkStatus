using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Dto;
using NetworkStatus.Models;

namespace NetworkStatus.Mappers
{
    public class Mapper : IMapper
    {
        public NodeStatus Map(NodeStatusDto status)
        {
            return new NodeStatus
            {
                HardwareStatus = status.HardwareStatus,

            };
        }
    }
}
