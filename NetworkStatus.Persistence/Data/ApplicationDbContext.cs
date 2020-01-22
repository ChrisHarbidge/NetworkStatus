using System;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Persistence.Models;

namespace NetworkStatus.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NodeStatus> NodeStatus { get; set; }
        public DbSet<HardwareStatusModel> HardwareStatus { get; set; }
        public DbSet<LinuxServiceStatus> LinuxServiceStatus { get; set; }
        public DbSet<NetworkStatusModel> NetworkStatus { get; set; }
        public DbSet<StorageStatus> StorageStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-NetworkStatus-FE05F8D6-70DF-4548-8C30-DF9503BFCB22;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HardwareStatusModel>()
                .HasOne(status => status.Node)
                .WithMany(node => node.HardwareStatus)
                .HasForeignKey(status => status.NodeId)
                .HasConstraintName("ForeignKey_Hardware_Node");

            builder.Entity<LinuxServiceStatus>()
                .HasOne(status => status.Node)
                .WithMany(node => node.Services)
                .HasForeignKey(status => status.NodeId)
                .HasConstraintName("ForeignKey_ServiceStatus_Node");

            builder.Entity<NetworkStatusModel>()
                .HasOne(status => status.Node)
                .WithMany(node => node.Network)
                .HasForeignKey(status => status.NodeId)
                .HasConstraintName("ForeignKey_Network_Node");

            builder.Entity<StorageStatus>()
                .HasOne(status => status.Node)
                .WithMany(node => node.Storage)
                .HasForeignKey(status => status.NodeId)
                .HasConstraintName("ForeignKey_Storage_Node");
            
            Seed(builder);
        }

        private static void Seed(ModelBuilder builder)
        { 
            var dateSent = DateTime.Now;

            var hardwareStatus = new HardwareStatusModel
            {
                Id = 1,
                NodeId = 1,
                CpuUsage = 50.0m,
                RamUsage = 1.5m,
                Temperature = 30.0m,
                TotalRam = 4,
                DateSent = dateSent
            };

            var networkStatus = new Models.NetworkStatusModel
            {
                Id = 1,
                NodeId = 1,
                DownloadSpeed = 1.0m,
                IsVpn = true,
                PrivateIpAddress = "192.168.0.30",
                PublicIpAddress = "1.1.1.1",
                DateSent = dateSent
            };

            var serviceStatus = new LinuxServiceStatus
            {
                Id = 1,
                NodeId = 1,
                IsRunning = true,
                ServiceName = "Test service",
                DateSent = dateSent
            };

            var storageStatus = new StorageStatus
            {
                Id = 1,
                NodeId = 1,
                TotalStorageSpaceBytes = 10000000,
                UsedStorageSpaceBytes = 50000,
                DateSent = dateSent
            };

            var nodeStatus = new NodeStatus
            {
                Id = 1,
                HardwareStatus = new Collection<HardwareStatusModel>()
                {
                    hardwareStatus
                },
                LastPinged = dateSent,
                NodeName = "Test Node",
                Network = new Collection<Models.NetworkStatusModel>()
                {
                    networkStatus
                },
                Services = new Collection<LinuxServiceStatus>()
                {
                    serviceStatus
                },
                Storage = new Collection<StorageStatus>()
                {
                    storageStatus
                }
            };
            
            builder.Entity<NodeStatus>().HasData(nodeStatus);
            builder.Entity<HardwareStatusModel>().HasData(hardwareStatus);
            builder.Entity<NetworkStatusModel>().HasData(networkStatus);
            builder.Entity<LinuxServiceStatus>().HasData(serviceStatus);
            builder.Entity<StorageStatus>().HasData(storageStatus);
        }
    }
}
