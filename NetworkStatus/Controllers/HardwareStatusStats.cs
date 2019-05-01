using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Data;
using NetworkStatus.Models;

namespace NetworkStatus.Controllers
{
    public class HardwareStatusStats : Controller
    {
        private readonly ApplicationDbContext _context;

        public HardwareStatusStats(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HardwareStatusStats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HardwareStatus.Include(h => h.Node);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
