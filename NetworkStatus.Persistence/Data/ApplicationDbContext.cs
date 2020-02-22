using System;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Seeding;

namespace NetworkStatus.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

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
             // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-NetworkStatus-FE05F8D6-70DF-4548-8C30-DF9503BFCB22;Trusted_Connection=True;MultipleActiveResultSets=true");
            // optionsBuilder.EnableSensitiveDataLogging();
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
            var generator = new SeedDataGenerator(10);

            var nodeStatus = new NodeStatus
            {
                Id = 1,
                LastPinged = DateTime.Now,
                NodeName = "Test Node"
            };

            var hardwareStatuses = generator.GenerateHardwareStatuses(1);
            
            builder.Entity<HardwareStatusModel>().HasData(hardwareStatuses);
            builder.Entity<NetworkStatusModel>().HasData(generator.GenerateNetworkStatuses(1));
            builder.Entity<LinuxServiceStatus>().HasData(generator.GenerateServiceStatuses(1));
            builder.Entity<StorageStatus>().HasData(generator.GenerateStorageStatuses(1));
            builder.Entity<NodeStatus>().HasData(nodeStatus);

        }
    }
}
