using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Persistence.Data;
using NetworkStatus.Persistence.Models;

namespace NetworkStatus.Persistence.Repositories
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

        public async Task<ICollection<HardwareStatusModel>> GetHardwareStatusesForNode(int nodeId)
        {
            return await _context.HardwareStatus.Where(status => status.NodeId == nodeId).ToListAsync();
        }

        public async Task<ICollection<HardwareStatusModel>> Index()
        {
            return await _context.HardwareStatus.ToListAsync();
        }
    }
}
