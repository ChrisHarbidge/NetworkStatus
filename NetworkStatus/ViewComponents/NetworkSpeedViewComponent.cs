using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Models;

namespace NetworkStatus.ViewComponents
{
    [ViewComponent( Name = "NetworkSpeed" )]
    public class NetworkSpeedViewComponent : ViewComponent
    {
        private readonly INetworkStatusRepository _networkStatusRepository;

        public NetworkSpeedViewComponent(INetworkStatusRepository networkStatusRepository)
        {
            _networkStatusRepository = networkStatusRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<NetworkStatusModel> networkStatuses)
        {
            return View(networkStatuses);
        }
    }
}
