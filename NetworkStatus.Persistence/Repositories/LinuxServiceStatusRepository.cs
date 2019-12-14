using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Persistence.Data;
using NetworkStatus.Persistence.Models;

namespace NetworkStatus.Persistence.Repositories
{
    public class LinuxServiceStatusRepository : ILinuxServiceStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public LinuxServiceStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<LinuxServiceStatus>> GetLatestServiceStatusesForNode(int nodeId)
        {
            return await _context.LinuxServiceStatus
                .Where(status => status.NodeId == nodeId)
                .GroupBy(status => status.ServiceName,
                    (key, statuses) => statuses
                        .OrderBy(serviceStatus => serviceStatus.DateSent)
                        .Last()).ToListAsync();
        }

        public async Task AddLinuxServiceStatuses(ICollection<LinuxServiceStatus> statuses, int NodeId)
        {
            statuses.ToList().ForEach(status => status.NodeId = NodeId);

            _context.LinuxServiceStatus.AddRange(statuses);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<LinuxServiceStatus>> GetLinuxServiceStatusesForNode(int nodeId)
        {
            return await _context.LinuxServiceStatus.Where(status => status.NodeId == nodeId).ToListAsync();
        }

        public async Task<ICollection<LinuxServiceStatus>> Index()
        {
            return await _context.LinuxServiceStatus.ToListAsync();
        }
    }
}
