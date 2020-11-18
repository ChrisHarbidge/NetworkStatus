using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Persistence.Data;
using NetworkStatus.Persistence.Models;

namespace NetworkStatus.Persistence.Repositories
{
    public class NodeStatusRepository : INodeStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public NodeStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNodeStatus(NodeStatus status)
        {
            _context.NodeStatus.Add(status);
            await _context.SaveChangesAsync();
        }

        public Task<NodeStatus> Get(int nodeId)
        {
            return _context.NodeStatus
                .Include(node => node.Storage)
                .Include(node => node.Network)
                .Include(node => node.Services)
                .Include(node => node.HardwareStatus)
                .SingleOrDefaultAsync(node => node.Id == nodeId);
        }

        public async Task<ICollection<NodeStatus>> Index()
        {
            return await _context.NodeStatus
                .Include(node => node.Storage)
                .Include(node => node.Network)
                .Include(node => node.Services)
                .Include(node => node.HardwareStatus)
                .ToListAsync();
        }

        public bool NodeStatusExists(string nodeName)
        {
            return _context.NodeStatus.Any(e => e.NodeName == nodeName);
        }

        public int GetId(string nodeName)
        {
            return _context.NodeStatus.First(node => node.NodeName.Equals(nodeName))
                .Id;
        }
    }
}
