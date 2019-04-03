using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using NetworkStatus.Data;
using NetworkStatus.Models;

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
                        CpuUsage = 50.0m,
                        LastPinged = DateTime.Now,
                        NodeName = "Test Node",
                        RamUsage = 1.5m,
                        Temperature = 30.0m,
                        TotalRam = 4
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
