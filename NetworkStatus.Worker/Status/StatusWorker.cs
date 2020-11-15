using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetworkStatus.Node;

namespace NetworkStatus.Worker.Status
{
    public class StatusWorker : BackgroundService
    {
        private readonly IStatusFetcher _statusFetcher;
        private readonly ILogger<StatusWorker> _logger;
        
        public StatusWorker(IStatusFetcher statusFetcher, ILogger<StatusWorker> logger)
        {
            _logger = logger;
            _statusFetcher = statusFetcher;
        }
    
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested == false)
            {
                var status = _statusFetcher.GetCurrentStatus();

                _logger.LogInformation(status.ToString());
                
                Thread.Sleep(1000);
            }
            
            return Task.CompletedTask;
        }
    }
}