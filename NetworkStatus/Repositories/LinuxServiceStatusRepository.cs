using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Data;
using NetworkStatus.Models;

namespace NetworkStatus.Repositories
{
    public class LinuxServiceStatusRepository : ILinuxServiceStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public LinuxServiceStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLinuxServiceStatuses(ICollection<LinuxServiceStatus> statuses, int NodeId)
        {
            statuses.ToList().ForEach(status => status.NodeId = NodeId);

            _context.LinuxServiceStatus.AddRange(statuses);

            await _context.SaveChangesAsync();
        }

        public Task<ICollection<LinuxServiceStatus>> GetLinuxServiceStatusesForNode(int nodeId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<LinuxServiceStatus>> Index()
        {
            throw new NotImplementedException();
        }
    }
}
