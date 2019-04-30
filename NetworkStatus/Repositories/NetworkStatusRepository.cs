using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<ICollection<NetworkStatusModel>> GetStatusesForNode(int nodeId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<NetworkStatusModel>> Index()
        {
            throw new NotImplementedException();
        }
    }
}
