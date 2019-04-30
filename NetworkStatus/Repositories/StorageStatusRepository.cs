using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Data;
using NetworkStatus.Models;

namespace NetworkStatus.Repositories
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

        public Task<ICollection<StorageStatus>> GetStorageStatusesForNode(int NodeId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<StorageStatus>> Index()
        {
            throw new NotImplementedException();
        }
    }
}
