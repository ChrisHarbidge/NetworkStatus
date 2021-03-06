﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Persistence.Data;
using NetworkStatus.Persistence.Models;

namespace NetworkStatus.Persistence.Repositories
{
    public class StorageStatusRepository : IStorageStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public StorageStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddStorageStatus(StorageStatus storageStatus, int NodeId)
        {
            storageStatus.NodeId = NodeId;

            _context.StorageStatus.Add(storageStatus);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<StorageStatus>> GetStorageStatusesForNode(int NodeId)
        {
            return await _context.StorageStatus.Where(status => status.NodeId == NodeId).ToListAsync();
        }

        public async Task<ICollection<StorageStatus>> Index()
        {
            return await _context.StorageStatus.ToListAsync();
        }
    }
}
