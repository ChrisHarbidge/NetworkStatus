using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Repositories;
using System.Collections.Generic;
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

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<NetworkStatusModel> networkStatuses)
        {
            return View(networkStatuses);
        }
    }
}
