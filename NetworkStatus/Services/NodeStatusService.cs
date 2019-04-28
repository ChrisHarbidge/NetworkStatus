using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Dto;
using NetworkStatus.Dto.Response;
using NetworkStatus.Mappers;
using NetworkStatus.Models;
using NetworkStatus.Repositories;

namespace NetworkStatus.Services
{
    public class NodeStatusService : INodeStatusService
    {
        private INodeStatusRepository _nodeStatusRepository;
        private IMapper _mapper;

        public NodeStatusService(INodeStatusRepository nodeStatusRepository, IMapper mapper)
        {
            _nodeStatusRepository = nodeStatusRepository;
            _mapper = mapper;
        }

        public async Task AddNodeStatus(NodeStatusDto nodeStatus)
        {
            // TODO: Mapping

            throw new NotImplementedException();

        }

        public bool Exists(int nodeId)
        {
            return _nodeStatusRepository.NodeStatusExists(nodeId);
        }

        public async Task<IEnumerable<NodeStatusResponseDto>> Index()
        {
            return (await _nodeStatusRepository.Index()).ToList().Select(_mapper.Map);
        }

        public async Task UpdateNodeStatus(NodeStatusDto nodeStatus)
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

            await Task.WhenAll(
            _nodeStatusRepository.AddHardwareStatus(_mapper.Map(hardwareStatus), nodeId),
            _nodeStatusRepository.AddLinuxServiceStatuses(linuxServiceStatuses.Select(_mapper.Map).ToList(), nodeId),
            _nodeStatusRepository.AddNetworkStatus(_mapper.Map(networkStatus), nodeId),
            _nodeStatusRepository.AddStorageStatus(_mapper.Map(storageStatus), nodeId)
            );
        }

        Task<NodeStatusResponseDto> INodeStatusService.Get(int nodeId)
        {
            throw new NotImplementedException();
        }
    }
}
