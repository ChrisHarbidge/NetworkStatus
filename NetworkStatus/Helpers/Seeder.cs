using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using NetworkStatus.Data;
using NetworkStatus.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

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

                var dateSent = DateTime.Now;

                context.NodeStatus.Add(
                    new NodeStatus
                    {
                        HardwareStatus = new Collection<HardwareStatusModel>()
                        {
                            new HardwareStatusModel
                            {
                                CpuUsage = 50.0m,
                                RamUsage = 1.5m,
                                Temperature = 30.0m,
                                TotalRam = 4,
                                DateSent = dateSent
                            }
                        },
                        LastPinged = dateSent,
                        NodeName = "Test Node",

                        Network = new Collection<Models.NetworkStatusModel>()
                        {
                            new Models.NetworkStatusModel
                            {
                                DownloadSpeed = 1.0m,
                                IsVpn = true,
                                PrivateIpAddress = "192.168.0.30",
                                PublicIpAddress = "1.1.1.1",
                                DateSent = dateSent
                            }
                        },
                        Services = new Collection<LinuxServiceStatus>()
                        {
                            new LinuxServiceStatus
                            {
                                IsRunning = true,
                                ServiceName = "Test service",
                                DateSent = dateSent
                            }
                        },
                        Storage = new Collection<StorageStatus>()
                        {
                            new StorageStatus
                            {
                                TotalStorageSpaceBytes = 10000000,
                                UsedStorageSpaceBytes = 50000,
                                DateSent = dateSent
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
