using B2CWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace B2CWebsite.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly DrugStoreContext _context;
        public ManufacturerController(DrugStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allManu = await _context.Manufacturers.ToListAsync();
            return View();
        }
    }
}
