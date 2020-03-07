﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Persistence.Models;
using NetworkStatus.Persistence.Repositories;

namespace NetworkStatus.WebApi.ViewComponents
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
