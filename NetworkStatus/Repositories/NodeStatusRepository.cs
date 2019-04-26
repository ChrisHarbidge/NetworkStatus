using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Data;
using NetworkStatus.Models;

namespace NetworkStatus.Repositories
{
    public class NodeStatusRepository : INodeStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public NodeStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddHardwareStatus(HardwareStatusModel hardwareStatus, int NodeId)
        {
            throw new NotImplementedException();
        }

        public Task AddLinuxServiceStatuses(ICollection<LinuxServiceStatus> statuses, int NodeId)
        {
            throw new NotImplementedException();
        }

        public Task AddNetworkStatus(NetworkStatusModel networkStatus, int NodeId)
        {
            throw new NotImplementedException();
        }

        public Task AddNodeStatus(NodeStatus status)
        {
            throw new NotImplementedException();
        }

        public Task AddStorageStatus(StorageStatus storageStatus, int NodeId)
        {
            throw new NotImplementedException();
        }

        public Task<NodeStatus> Get(int nodeId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<NodeStatus>> Index()
        {
            return await _context.NodeStatus
                .Include(node => node.Storage)
                .Include(node => node.Network)
                .Include(node => node.Services)
                .ToListAsync();
        }
    }
}
