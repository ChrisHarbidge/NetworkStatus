using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetworkStatus.ViewComponents
{
    [ViewComponent(Name = "RamUsage")]
    public class RamUsageViewComponent : ViewComponent
    {

        private readonly IHardwareStatusRepository _hardwareStatusRepository;

        public RamUsageViewComponent(IHardwareStatusRepository hardwareStatusRepository)
        {
            _hardwareStatusRepository = hardwareStatusRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<HardwareStatusModel> statuses)
        {
            return View(statuses);
        }
    }
}
