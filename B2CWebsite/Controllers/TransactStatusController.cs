using B2CWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2CWebsite.Controllers
{
    public class TransactStatusController : Controller
    {
        private readonly DrugStoreContext _context;
        public TransactStatusController(DrugStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var order = await _context.TransactStatuses.ToListAsync();
            return View();
        }
    }
}
