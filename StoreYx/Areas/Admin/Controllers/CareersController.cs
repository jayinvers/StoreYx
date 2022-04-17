#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreYx.Data;
using StoreYx.Models;

namespace StoreYx.Areas.Admin.Controllers
{
    public class CareersController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public CareersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Careers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Career.ToListAsync());
        }

        // GET: Admin/Careers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Career
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // GET: Admin/Careers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Careers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Body,IsAvailable,CreatedAt")] Career career)
        {
            if (ModelState.IsValid)
            {
                career.CreatedAt = DateTime.Now;
                _context.Add(career);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(career);
        }

        // GET: Admin/Careers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Career.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }
            return View(career);
        }

        // POST: Admin/Careers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Body,IsAvailable,CreatedAt")] Career career)
        {
            if (id != career.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(career);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerExists(career.Id))
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
            return View(career);
        }

        // GET: Admin/Careers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Career
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // POST: Admin/Careers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var career = await _context.Career.FindAsync(id);
            _context.Career.Remove(career);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerExists(int id)
        {
            return _context.Career.Any(e => e.Id == id);
        }
    }
}
