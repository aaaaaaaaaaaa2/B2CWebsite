using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using B2CWebsite.Models;
using B2CWebsite.Helpper;

namespace B2CWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSupplementsController : Controller
    {
        private readonly DrugStoreContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AdminSupplementsController(DrugStoreContext context, IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
            _context = context;
        }

        // GET: Admin/AdminSupplements
        public async Task<IActionResult> Index()
        {
            var drugStoreContext = _context.Supplements.Include(s => s.Cat).Include(s => s.Manu);
            return View(await drugStoreContext.ToListAsync());
        }

        // GET: Admin/AdminSupplements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Supplements == null)
            {
                return NotFound();
            }

            var supplement = await _context.Supplements
                .Include(s => s.Cat)
                .Include(s => s.Manu)
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (supplement == null)
            {
                return NotFound();
            }

            return View(supplement);
        }

        // GET: Admin/AdminSupplements/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId");
            ViewData["ManuId"] = new SelectList(_context.Manufacturers, "ManuId", "ManuId");
            return View();
        }

        // POST: Admin/AdminSupplements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sid,Sname,Image,ManuId,CatId,Uses,Ingredient,Directions,Warnings,OtherInfo,InactiveIngredient,Price")] Supplement supplement)
        {
            // Add lạ khúc hình ảnh
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(supplement.Image.FileName);
                string extension = Path.GetExtension(supplement.Image.FileName);
                supplement.Slink =fileName =fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/img", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await supplement.Image.CopyToAsync(fileStream);
                }

                _context.Add(supplement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId", supplement.CatId);
            ViewData["ManuId"] = new SelectList(_context.Manufacturers, "ManuId", "ManuId", supplement.ManuId);
            return View(supplement);
        }

        // GET: Admin/AdminSupplements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Supplements == null)
            {
                return NotFound();
            }

            var supplement = await _context.Supplements.FindAsync(id);
            if (supplement == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId", supplement.CatId);
            ViewData["ManuId"] = new SelectList(_context.Manufacturers, "ManuId", "ManuId", supplement.ManuId);
            return View(supplement);
        }

        // POST: Admin/AdminSupplements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sid,Sname,Slink,ManuId,CatId,Uses,Ingredient,Directions,Warnings,OtherInfo,InactiveIngredient,Price")] Supplement supplement)
        {
            if (id != supplement.Sid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplementExists(supplement.Sid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId", supplement.CatId);
            ViewData["ManuId"] = new SelectList(_context.Manufacturers, "ManuId", "ManuId", supplement.ManuId);
            return View(supplement);
        }

        // GET: Admin/AdminSupplements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Supplements == null)
            {
                return NotFound();
            }

            var supplement = await _context.Supplements
                .Include(s => s.Cat)
                .Include(s => s.Manu)
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (supplement == null)
            {
                return NotFound();
            }

            return View(supplement);
        }

        // POST: Admin/AdminSupplements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Supplements == null)
            {
                return Problem("Entity set 'DrugStoreContext.Supplements'  is null.");
            }
            var supplement = await _context.Supplements.FindAsync(id);
            if (supplement != null)
            {
                _context.Supplements.Remove(supplement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplementExists(int id)
        {
          return _context.Supplements.Any(e => e.Sid == id);
        }
    }
}
