using AspNetCoreHero.ToastNotification.Abstractions;
using B2CWebsite.Extension;
using B2CWebsite.Helpper;
using B2CWebsite.Models;
using B2CWebsite.ModelViews;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace B2CWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly DrugStoreContext _context;
        public INotyfService _notyfService { get; }
        public AccountController(DrugStoreContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }


        [Route("Index.cshtml", Name = "Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var allAccount = await _context.Accounts.ToListAsync();
            var accountID = HttpContext.Session.GetString("AccountId");
            if (accountID != null)
            {
                var customer = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.AccountId == Convert.ToInt32(accountID));
                if (customer != null)
                {
                    var lsOrder = _context.Orders
                        .Include(x => x.TransactId)
                        .AsNoTracking()
                        .OrderByDescending(x => x.OrderDate)
                        .ToList();
                    ViewBag.DonHang = lsOrder;
                    return View(customer);
                }
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidatePhone(string Phone)
        {
            try
            {
                var customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Phone.ToLower() == Phone.ToLower());
                if (customer != null)
                    return Json(data: "Phone Number : " + Phone + "has been used");

                return Json(data: true);

            }
            catch
            {
                return Json(data: true);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string Email)
        {
            try
            {
                var customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
                if (customer != null)
                    return Json(data: "Email : " + Email + " has been used");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("register.html", Name = "Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register.html", Name = "Register")]
        public async Task<IActionResult> Register(RegisterViewModel account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string salt = Utilities.GetRandomKey();
                    Account customer = new Account
                    {
                        FullName = account.FullName,
                        Phone = account.Phone.Trim().ToLower(),
                        Email = account.Email.Trim().ToLower(),
                        Password = account.Password.Trim(),
                    };
                    try
                    {
                        _context.Add(customer);
                        await _context.SaveChangesAsync();
                        HttpContext.Session.SetString("AccountId", customer.AccountId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("AccountId");

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,customer.FullName),
                            new Claim("AccountId", customer.AccountId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Register successfully!");
                        return RedirectToAction("Index", "Home");
                    }
                    catch
                    {
                        return RedirectToAction("Register", "Accounts");
                    }
                }
                else
                {
                    return View(account);
                }
            }
            catch
            {
                return View(account);
            }
        }
        [AllowAnonymous]
        [Route("login.html", Name = "Login")]
        public IActionResult Login(string returnUrl = null)
        {
            var accountID = HttpContext.Session.GetString("CustomerId");
            if (accountID != null)
            {
                return RedirectToAction("Dashboard", "Accounts");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("login.html", Name = "Login")]
        public async Task<IActionResult> Login(LoginViewModel customer1, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(customer1.UserName);
                    if (!isEmail) return View(customer1);

                    var customer = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer1.UserName);

                    //Luu Session MaKh
                    HttpContext.Session.SetString("AccountId", customer.AccountId.ToString());
                    var taikhoanID = HttpContext.Session.GetString("CustomerId");

                    //Identity
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, customer.FullName),
                        new Claim("AccountId", customer.AccountId.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Success("Login Success");
                    if (string.IsNullOrEmpty(returnUrl))
                    {   
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
            }
            catch
            {
                return RedirectToAction("Register", "Accounts");
            }
            return View(customer1);
        }
        [HttpGet]
        [Route("logout.html", Name = "Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("Index", "Home");
        }
    }
}
