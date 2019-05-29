using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Models;

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
