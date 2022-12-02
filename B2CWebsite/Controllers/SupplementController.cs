using B2CWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Details(int id)
        {
            var data = _context.Supplements.Include(x => x.Cat).FirstOrDefault(x => x.Sid == id);
           /* if (data == null)
            {
                return RedirectToAction("Index");
            }*/
            return View();
        }
    }
}
