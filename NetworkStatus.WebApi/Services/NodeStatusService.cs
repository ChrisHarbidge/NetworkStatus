using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Persistence.Repositories;
using NetworkStatus.Dto.Response;
using NetworkStatus.WebApi.Mappers;
using NetworkStatus.Contract.Request;

namespace NetworkStatus.WebApi.Services
{
    public class NodeStatusService : INodeStatusService
    {
        private readonly INodeStatusRepository _nodeStatusRepository;
        private readonly IHardwareStatusRepository _hardwareStatusRepository;
        private readonly ILinuxServiceStatusRepository _linuxServiceStatusRepository;
        private readonly INetworkStatusRepository _networkStatusRepository;
        private readonly IStorageStatusRepository _storageStatusRepository;

        private readonly IMapper _mapper;

        public NodeStatusService(INodeStatusRepository nodeStatusRepository, 
            IHardwareStatusRepository hardwareStatusRepository,
            ILinuxServiceStatusRepository linuxServiceStatusRepository,
            INetworkStatusRepository networkStatusRepository,
            IStorageStatusRepository storageStatusRepository,
            IMapper mapper)
        {
            _nodeStatusRepository = nodeStatusRepository;
            _hardwareStatusRepository = hardwareStatusRepository;
            _linuxServiceStatusRepository = linuxServiceStatusRepository;
            _networkStatusRepository = networkStatusRepository;
            _storageStatusRepository = storageStatusRepository;
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
            _hardwareStatusRepository.AddHardwareStatus(_mapper.Map(hardwareStatus), nodeId),
            _linuxServiceStatusRepository.AddLinuxServiceStatuses(linuxServiceStatuses.Select(_mapper.Map).ToList(), nodeId),
            _networkStatusRepository.AddNetworkStatus(_mapper.Map(networkStatus), nodeId),
            _storageStatusRepository.AddStorageStatus(_mapper.Map(storageStatus), nodeId)
            );
        }

        Task<NodeStatusResponseDto> INodeStatusService.Get(int nodeId)
        {
            throw new NotImplementedException();
        }
    }
}
