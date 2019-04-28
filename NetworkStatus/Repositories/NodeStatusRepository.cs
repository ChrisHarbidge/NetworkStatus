﻿using System;
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

        public async Task AddHardwareStatus(HardwareStatusModel hardwareStatus, int NodeId)
        {
            hardwareStatus.NodeId = NodeId;

            _context.HardwareStatus.Add(hardwareStatus);

            await _context.SaveChangesAsync();
        }

        public async Task AddLinuxServiceStatuses(ICollection<LinuxServiceStatus> statuses, int NodeId)
        {
            statuses.ToList().ForEach(status => status.NodeId = NodeId);

            _context.LinuxServiceStatus.AddRange(statuses);

            await _context.SaveChangesAsync();
        }

        public async Task AddNetworkStatus(NetworkStatusModel networkStatus, int NodeId)
        {
            networkStatus.NodeId = NodeId;

            _context.NetworkStatus.Add(networkStatus);

            await _context.SaveChangesAsync();
        }

        public async Task AddNodeStatus(NodeStatus status)
        {
            _context.NodeStatus.Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task AddStorageStatus(StorageStatus storageStatus, int NodeId)
        {
            storageStatus.NodeId = NodeId;

            _context.StorageStatus.Add(storageStatus);

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

        public bool NodeStatusExists(int id)
        {
            return _context.NodeStatus.Any(e => e.Id == id);
        }
    }
}
