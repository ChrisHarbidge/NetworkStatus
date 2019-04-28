using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Models;

namespace NetworkStatus.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
        }

    }
}
