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
            var listenerTask = _listenerServer.Listen(stoppingToken);

            await Task.WhenAll(listenerTask);
        }
    }
}