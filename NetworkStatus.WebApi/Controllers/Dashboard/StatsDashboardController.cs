using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Repositories;

namespace NetworkStatus.Controllers.Dashboard
{
    [Route("[controller]")]
    [Route("dashboard")]
    public class StatsDashboardController : Controller
    {
        private readonly IHardwareStatusRepository _hardwareStatusRepository;
        private readonly INetworkStatusRepository _networkStatusRepository;
        private readonly ILinuxServiceStatusRepository _linuxServiceStatusRepository;

        public StatsDashboardController(IHardwareStatusRepository hardwareStatusRepository, INetworkStatusRepository networkStatusRepository, ILinuxServiceStatusRepository linuxServiceStatusRepository)
        {
            _hardwareStatusRepository = hardwareStatusRepository;
            _networkStatusRepository = networkStatusRepository;
            _linuxServiceStatusRepository = linuxServiceStatusRepository;
        }

        public async Task<IActionResult> Index()
        {
            var hardwareStatuses = _hardwareStatusRepository.GetHardwareStatusesForNode(1);
            var networkStatuses = _networkStatusRepository.GetStatusesForNode(1); 
            var linuxServiceStatuses = _linuxServiceStatusRepository.GetLatestServiceStatusesForNode(1);

            await Task.WhenAll(hardwareStatuses, networkStatuses,
                linuxServiceStatuses
                );

            return View(new StatsDashboardModel
            {
                HardwareStatuses = hardwareStatuses.Result,
                NetworkStatuses = networkStatuses.Result,
                LinuxServiceStatuses = linuxServiceStatuses.Result
            });
        }
    }
}