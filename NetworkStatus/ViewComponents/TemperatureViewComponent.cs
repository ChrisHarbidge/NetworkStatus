using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkStatus.Models;

namespace NetworkStatus.ViewComponents
{
    [ViewComponent( Name = "Temperature" )]
    public class TemperatureViewComponent : ViewComponent
    {
        private readonly IHardwareStatusRepository _hardwareStatusRepository;

        public TemperatureViewComponent(IHardwareStatusRepository hardwareStatusRepository)
        {
            _hardwareStatusRepository = hardwareStatusRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<HardwareStatusModel> hardwareStatuses)
        {
            return View(hardwareStatuses);
        }
    }
}
