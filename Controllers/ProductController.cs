using Microsoft.AspNetCore.Mvc;
using TechMarketSweden.Data;
using Microsoft.EntityFrameworkCore;

namespace TechMarketSweden.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
    }
}
