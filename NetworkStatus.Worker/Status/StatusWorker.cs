using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetworkStatus.Node;
using NetworkStatus.Worker.Client;

namespace NetworkStatus.Worker.Status
{
    public class StatusWorker : BackgroundService
    {
        private readonly IStatusFetcher _statusFetcher;
        private readonly IApiClient _apiClient;
        private readonly IExternalNodesBank _externalNodesBank;
        private readonly ILogger<StatusWorker> _logger;

        public StatusWorker(IStatusFetcher statusFetcher, IApiClient apiClient, IExternalNodesBank externalNodesBank, ILogger<StatusWorker> logger)
        {
            _statusFetcher = statusFetcher;
            _apiClient = apiClient;
            _externalNodesBank = externalNodesBank;
            _logger = logger;
        }
    
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested == false)
            {
                var status = _statusFetcher.GetCurrentStatus();

                _logger.LogInformation(status.ToString());

                _logger.LogInformation("Pushing to api");
                
                Parallel.ForEach(_externalNodesBank.GetKnownHosts(),
                    async address => await _apiClient.SendStatus(status, address));
                
                Thread.Sleep(30000);
            }
            
            return Task.CompletedTask;
        }
    }
}