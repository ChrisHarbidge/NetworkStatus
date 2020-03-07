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
        private readonly IHardwareStatusRepository _hardwareStatusRepository;

        public CpuUsageViewComponent(IHardwareStatusRepository hardwareStatusRepository)
        {
            _hardwareStatusRepository = hardwareStatusRepository;
        }

        // TODO: Don't always use the repository, as multiple fetches aren't necessary
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<HardwareStatusModel> hardwareStatuses)
        {
            return View(hardwareStatuses);
        }
    }
}
