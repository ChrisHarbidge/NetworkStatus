using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetworkStatus.Worker.Publisher
{
    public class ClientWorker : BackgroundService
    {
        private readonly ILogger<ClientWorker> _logger;
        private readonly IPublishClient _publishClient;

        public ClientWorker(ILogger<ClientWorker> logger, IPublishClient publishClient)
        {
            _logger = logger;
            _publishClient = publishClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested == false)
            {
                await _publishClient.Connect(stoppingToken);
                _logger.LogInformation("ClientWorker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}