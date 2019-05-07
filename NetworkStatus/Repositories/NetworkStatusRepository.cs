using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Data;
using NetworkStatus.Models;

namespace NetworkStatus.Repositories
{
    public class NetworkStatusRepository : INetworkStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public NetworkStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNetworkStatus(NetworkStatusModel networkStatus, int nodeId)
        {
            networkStatus.NodeId = nodeId;

            _context.NetworkStatus.Add(networkStatus);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<NetworkStatusModel>> GetStatusesForNode(int nodeId)
        {
            return await _context.NetworkStatus.Where(status => status.NodeId == nodeId).ToListAsync();
        }

        public Task<ICollection<NetworkStatusModel>> Index()
        {
            throw new NotImplementedException();
        }
    }
}
