using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetworkStatus.Node;
using NetworkStatus.Node.Configuration;
using NetworkStatus.Node.Status.Device;

namespace NetworkStatus.Worker.Status
{
    public class StatusWorker : BackgroundService
    {
        // TODO: Clean up these dependencies, make Node injectable
        private readonly IHardwareStatusService _hardwareStatusService;
        private readonly StatusFetcher _statusFetcher;
        private readonly ILogger<StatusWorker> _logger;
        
        public StatusWorker(IHardwareStatusService hardwareStatusService, ILogger<StatusWorker> logger)
        {
            _hardwareStatusService = hardwareStatusService;
            _logger = logger;
            
            var configuration = new NodeConfiguration();
            _statusFetcher = new StatusFetcher(configuration, _hardwareStatusService);
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