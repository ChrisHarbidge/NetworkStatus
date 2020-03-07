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
        public IViewComponentResult Invoke(IEnumerable<NetworkStatusModel> networkStatuses)
        {
            return View(networkStatuses);
        }
    }
}
