using B2CWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2CWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly DrugStoreContext _context;
        public AccountController(DrugStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allAccount = await _context.Accounts.ToListAsync();
            return View();
        }
    }
}
