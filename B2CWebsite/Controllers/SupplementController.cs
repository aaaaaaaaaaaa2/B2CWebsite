using B2CWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Linq;

namespace B2CWebsite.Controllers
{
    public class SupplementController : Controller
    {
        private readonly DrugStoreContext _context;
        public SupplementController(DrugStoreContext context)
        {
            _context = context;
        }
        [Route("shop.html", Name = ("ShopProduct"))]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsSupplements = _context.Supplements
                 .AsNoTracking()
                 .OrderByDescending(x => x.Sid);
                PagedList<Supplement> models = new PagedList<Supplement>(lsSupplements,pageNumber,pageSize);
                ViewBag.CurrentPage = page;
                return View(models);
            }
            catch 
            { 
                return RedirectToAction("Index","Home");
            }

        }
        public IActionResult List(int CatID, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var cat = _context.Categories.Find(CatID);
                var lsSupplements = _context.Supplements
                    .AsNoTracking()
                    .Where(x => x.CatId == CatID)
                    .OrderByDescending(x => x.Sid);
                PagedList<Supplement> models = new PagedList<Supplement>(lsSupplements, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = cat;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/{Name}-{id}.html", Name = ("ProductDetails"))]
        public IActionResult Details(int id)
        {
            var data = _context.Supplements.Include(x => x.Cat).FirstOrDefault(x => x.Sid == id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
                return View();
        }
    }
}
