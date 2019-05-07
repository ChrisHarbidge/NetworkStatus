using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IViewComponentResult> InvokeAsync(
        int nodeId)
        {
            var items = await _networkStatusRepository.GetStatusesForNode(nodeId);
            return View(items);

        }
    }
}
