using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Models;
using NetworkStatus.Repositories;

namespace NetworkStatus.Controllers.Dashboard
{
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
            var hardwareStatuses = _hardwareStatusRepository.GetHardwareStatusesForNode(2);
            var networkStatuses = _networkStatusRepository.GetStatusesForNode(2);
            var linuxServiceStatuses = _linuxServiceStatusRepository.GetLatestServiceStatusesForNode(2);

            return View(new StatsDashboardModel
            {
                HardwareStatuses = hardwareStatuses.Result,
                NetworkStatuses = networkStatuses.Result,
                LinuxServiceStatuses = linuxServiceStatuses.Result
            });
        }
    }
}