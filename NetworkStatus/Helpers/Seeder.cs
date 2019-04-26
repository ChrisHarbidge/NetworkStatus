using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using NetworkStatus.Data;
using NetworkStatus.Models;
using System.Collections.ObjectModel;

namespace NetworkStatus.Helpers
{
    public static class Seeder
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.NodeStatus.Any())
                {
                    return;
                }

                context.NodeStatus.Add(
                    new NodeStatus {
                        HardwareStatus = new HardwareStatusModel
                        {
                            CpuUsage = 50.0m,
                            RamUsage = 1.5m,
                            Temperature = 30.0m,
                            TotalRam = 4,
                        },
                        LastPinged = DateTime.Now,
                        NodeName = "Test Node",
                        
                        Network = new Models.NetworkStatus {
                            DownloadSpeed = 1.0m,
                            IsVpn = true,
                            PrivateIpAddress = "192.168.0.30",
                            PublicIpAddress = "1.1.1.1"
                        },
                        Services = new Collection<LinuxServiceStatus>()
                        {
                            new LinuxServiceStatus
                            {
                                IsRunning = true,
                                ServiceName = "Test service"
                            }
                        },
                        Storage = new StorageStatus
                        {
                            TotalStorageSpaceBytes = 10000000,
                            UsedStorageSpaceBytes = 50000
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
