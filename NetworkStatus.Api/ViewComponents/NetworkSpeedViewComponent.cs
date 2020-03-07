using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Repositories;

namespace NetworkStatus.WebApi.ViewComponents
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
