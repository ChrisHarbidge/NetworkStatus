using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Repositories;

namespace NetworkStatus.WebApi.ViewComponents
{
    [ViewComponent( Name = "CpuUsage" )]
    public class CpuUsageViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<HardwareStatusModel> hardwareStatuses)
        {
            return View(hardwareStatuses);
        }
    }
}
