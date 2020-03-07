using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Repositories;

namespace NetworkStatus.WebApi.ViewComponents
{
    [ViewComponent(Name = "RamUsage")]
    public class RamUsageViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<HardwareStatusModel> statuses)
        {
            return View(statuses);
        }
    }
}
