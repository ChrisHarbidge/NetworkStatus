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

        public StatsDashboardController(IHardwareStatusRepository hardwareStatusRepository, INetworkStatusRepository networkStatusRepository)
        {
            _hardwareStatusRepository = hardwareStatusRepository;
            _networkStatusRepository = networkStatusRepository; 
        }


        public async Task<IActionResult> Index()
        {
            var hardwareStatuses = _hardwareStatusRepository.GetHardwareStatusesForNode(2);
            var networkStatuses = _networkStatusRepository.GetStatusesForNode(2);

            return View(new StatsDashboardModel
            {
                HardwareStatuses = hardwareStatuses.Result,
                NetworkStatuses = networkStatuses.Result
            });
        }
    }
}