using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace NetworkStatus.Worker.Status
{
    public class StatusWorker : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}