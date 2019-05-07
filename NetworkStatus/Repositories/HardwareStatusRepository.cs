﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<HardwareStatusModel>> GetHardwareStatusesForNode(int nodeId)
        {
            return await _context.HardwareStatus.Where(status => status.NodeId == nodeId).ToListAsync();
        }

        public Task<ICollection<HardwareStatusModel>> Index()
        {
            throw new NotImplementedException();
        }
    }
}
