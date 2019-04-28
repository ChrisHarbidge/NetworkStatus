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

                var nodeId = 2;

                context.NodeStatus.Add(
                    new NodeStatus
                    {
                        //Id = nodeId,
                        HardwareStatus = new Collection<HardwareStatusModel>()
                        {
                            new HardwareStatusModel
                            {
                                //NodeId = nodeId,
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
                                //NodeId = nodeId,
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
                                //NodeId = nodeId,
                                IsRunning = true,
                                ServiceName = "Test service",
                                DateSent = dateSent
                            }
                        },
                        Storage = new Collection<StorageStatus>()
                        {
                            new StorageStatus
                            {
                                //NodeId = nodeId,
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
