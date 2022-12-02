using B2CWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2CWebsite.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly DrugStoreContext _context;
        public OrderDetailController(DrugStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var orderDetail = await _context.OrderDetails.ToListAsync();
            return View();
        }
    }
}
