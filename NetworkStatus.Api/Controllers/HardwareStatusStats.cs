using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Persistence.Data;

namespace NetworkStatus.WebApi.Controllers
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
            // TODO: Move to repository
            var applicationDbContext = _context.HardwareStatus.Include(h => h.Node);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
