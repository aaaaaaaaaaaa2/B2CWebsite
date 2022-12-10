using AspNetCoreHero.ToastNotification.Abstractions;
using B2CWebsite.Extension;
using B2CWebsite.Models;
using B2CWebsite.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace B2CWebsite.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly DrugStoreContext _context;
        public INotyfService _notyfService { get; }
        public CheckOutController(DrugStoreContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<CartItem> ShoppingCart
        {
            get
            {
                var cart = HttpContext.Session.Get<List<CartItem>>("ShoppingCart");
                if (cart == default(List<CartItem>))
                {
                    cart = new List<CartItem>();
                }
                return cart;
            }
        }
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(string returnUrl = null)     
        {
            return View();
        }
    }
}
