using B2CWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2CWebsite.Controllers
{
    public class RoleController : Controller
    {
        private readonly DrugStoreContext _context;
        public RoleController(DrugStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var order = await _context.Roles.ToListAsync();
            return View();
        }
    }
}
