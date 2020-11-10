using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetworkStatus.Worker.Listener
{
    public class ServerWorker : BackgroundService
    {
        private readonly ILogger<ServerWorker> _logger;
        private readonly IListenerServer _listenerServer;

        public ServerWorker(ILogger<ServerWorker> logger, IListenerServer listenerServer)
        {
            _logger = logger;
            _listenerServer = listenerServer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting server worker");

            try
            {
                var listenerTask = _listenerServer.Listen(stoppingToken);
                await listenerTask;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}