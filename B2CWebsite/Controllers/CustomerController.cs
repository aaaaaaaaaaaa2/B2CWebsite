using B2CWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace B2CWebsite.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DrugStoreContext _context;
        public CustomerController(DrugStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCustomer = await _context.Customers.ToListAsync();
            return View();
        }
    }
}
