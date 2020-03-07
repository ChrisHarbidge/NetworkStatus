using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Repositories;

namespace NetworkStatus.WebApi.ViewComponents
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
