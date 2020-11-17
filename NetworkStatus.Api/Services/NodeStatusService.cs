using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Persistence.Repositories;
using NetworkStatus.WebApi.Mappers;
using NetworkStatus.Contract.Request;
using NetworkStatus.Contract.Response;

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

        public async Task AddNodeStatus(NodeStatusDto nodeStatusDto)
        {
            var nodeStatus = _mapper.Map(nodeStatusDto);
            await _nodeStatusRepository.AddNodeStatus(nodeStatus);
        }

        public bool Exists(string nodeName)
        {
            return _nodeStatusRepository.NodeStatusExists(nodeName);
        }

        public async Task<IEnumerable<NodeStatusResponseDto>> Index()
        {
            return (await _nodeStatusRepository.Index()).ToList().Select(_mapper.Map);
        }

        public async Task UpsertNodeStatus(NodeStatusDto nodeStatus)
        {
            if (!Exists(nodeStatus.NodeName))
            {
                await AddNodeStatus(nodeStatus);
            }
            
            var dateSent = DateTime.Now;

            var hardwareStatus = nodeStatus.HardwareStatus;
            hardwareStatus.DateSent = dateSent;

            var storageStatus = nodeStatus.Storage;
            storageStatus.DateSent = dateSent;

            var networkStatus = nodeStatus.Network;
            networkStatus.DateSent = dateSent;

            var linuxServiceStatuses = nodeStatus.Services.ToList();
            linuxServiceStatuses.ForEach(status => status.DateSent = dateSent);

            var nodeId = _nodeStatusRepository.GetId(nodeStatus.NodeName);

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
