using AspNetCoreHero.ToastNotification.Abstractions;
using B2CWebsite.Extension;
using B2CWebsite.Models;
using B2CWebsite.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace B2CWebsite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly DrugStoreContext _context;
        public INotyfService _notyfService { get; }
        public ShoppingCartController(DrugStoreContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<CartItem> ShoppingCart
        {
            get
            {
                var sc = HttpContext.Session.Get<List<CartItem>>("ShoppingCart");
                if (sc == default(List<CartItem>))
                {
                    sc = new List<CartItem>();
                }
                return sc;
            }
        }
        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int SID, int? amount)
        {
            List<CartItem> cart = ShoppingCart;

            try
            {
                CartItem item = cart.SingleOrDefault(p => p.supplement.Sid == SID);
                if (item != null) 
                {
                    item.amount = item.amount + amount.Value;
                    //save session
                    HttpContext.Session.Set<List<CartItem>>("ShoppingCart", cart);
                }
                else
                {
                    Supplement hh = _context.Supplements.SingleOrDefault(p => p.Sid == SID);
                    item = new CartItem
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        supplement = hh
                    };
                    cart.Add(item);
                }

                //save
                HttpContext.Session.Set<List<CartItem>>("ShoppingCart", cart);
                _notyfService.Success("Added product successfully to the cart");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int SID, int? amount)
        {

            var cart1 = HttpContext.Session.Get<List<CartItem>>("ShoppingCart");
            try
            {
                if (cart1 != null)
                {
                    CartItem item = cart1.SingleOrDefault(p => p.supplement.Sid == SID);
                    if (item != null && amount.HasValue)
                    {
                        item.amount = amount.Value;
                    }
                    //Luu lai session
                    HttpContext.Session.Set<List<CartItem>>("ShoppingCart", cart1);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        [Route("api/cart/remove")]
        public ActionResult Remove(int SID)
        {

            try
            {
                List<CartItem>  cart = ShoppingCart;
                CartItem item = cart.SingleOrDefault(p => p.supplement.Sid == SID);
                if (item != null)
                {
                    cart.Remove(item);
                }
                //luu lai session
                HttpContext.Session.Set<List<CartItem>>("ShoppingCart", cart);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [Route("cart.html", Name = "Cart")]
        public IActionResult Index()
        {
            return View(ShoppingCart);
        }
    }
}
