using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Dto;
using NetworkStatus.Models;
using NetworkStatus.Repositories;

namespace NetworkStatus.Services
{
    public class NodeStatusService : INodeStatusService
    {
        private INodeStatusRepository _nodeStatusRepository;

        public NodeStatusService(INodeStatusRepository nodeStatusRepository)
        {
            _nodeStatusRepository = nodeStatusRepository;
        }

        public Task<NodeStatus> Get(int nodeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NodeStatus>> Index()
        {
            return (await _nodeStatusRepository.Index()).ToList();
        }

        public void UpdateNodeStatus(NodeStatusDto nodeStatus)
        {
            var dateSent = DateTime.Now;

            var hardwareStatus = nodeStatus.HardwareStatus;
            hardwareStatus.DateSent = dateSent;

            var storageStatus = nodeStatus.Storage;
            storageStatus.DateSent = dateSent;

            var networkStatus = nodeStatus.Network;
            networkStatus.DateSent = dateSent;

            var linuxServiceStatuses = nodeStatus.Services.ToList();
            linuxServiceStatuses.ForEach(status => status.DateSent = dateSent);

            var nodeId = nodeStatus.Id;

            _nodeStatusRepository.AddHardwareStatus(hardwareStatus, nodeId);
            _nodeStatusRepository.AddLinuxServiceStatuses(linuxServiceStatuses, nodeId);
            _nodeStatusRepository.AddNetworkStatus(networkStatus, nodeId);
            _nodeStatusRepository.AddStorageStatus(storageStatus, nodeId);
        }
    }
}
