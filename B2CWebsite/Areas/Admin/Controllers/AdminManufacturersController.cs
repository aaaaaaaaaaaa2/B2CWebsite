using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using B2CWebsite.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace B2CWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminManufacturersController : Controller
    {
        private readonly DrugStoreContext _context;
        public INotyfService _notifyService { get; }

        public AdminManufacturersController(DrugStoreContext context, INotyfService notifyService)
        {
            _notifyService = notifyService;
            _context = context;
        }

        // GET: Admin/AdminManufacturers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Manufacturers.ToListAsync());
        }

        // GET: Admin/AdminManufacturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.ManuId == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // GET: Admin/AdminManufacturers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminManufacturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManuId,ManuName,ManuAddress,ManuPhone,ManuEmail,ManuCountry")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturer);
                await _context.SaveChangesAsync();
                _notifyService.Success("Create Successfully!");
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Admin/AdminManufacturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        // POST: Admin/AdminManufacturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManuId,ManuName,ManuAddress,ManuPhone,ManuEmail,ManuCountry")] Manufacturer manufacturer)
        {
            if (id != manufacturer.ManuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturer);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Edit Successfully!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.ManuId))
                    {
                        _notifyService.Success("Error!");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Admin/AdminManufacturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.ManuId == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST: Admin/AdminManufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Manufacturers == null)
            {
                return Problem("Entity set 'DrugStoreContext.Manufacturers'  is null.");
            }
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
            }
            
            await _context.SaveChangesAsync();
            _notifyService.Success("Delete Successfully!");
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerExists(int id)
        {
          return _context.Manufacturers.Any(e => e.ManuId == id);
        }
    }
}
