using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetworkStatus.Controllers.Dashboard
{
    public class StatsDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}