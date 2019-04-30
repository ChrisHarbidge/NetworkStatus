using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Data;
using NetworkStatus.Models;

namespace NetworkStatus.Repositories
{
    public class HardwareStatusRepository : IHardwareStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public HardwareStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddHardwareStatus(HardwareStatusModel hardwareStatus, int NodeId)
        {
            hardwareStatus.NodeId = NodeId;

            _context.HardwareStatus.Add(hardwareStatus);

            await _context.SaveChangesAsync();
        }

        public Task<ICollection<HardwareStatusModel>> GetHardwareStatusesForNode(int nodeId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HardwareStatusModel>> Index()
        {
            throw new NotImplementedException();
        }
    }
}
