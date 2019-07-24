using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiłoszGajowczykLab7.Services;
using MiłoszGajowczykLab7.Models;

namespace MiłoszGajowczykLab7.Controllers
{
    public class JumpersController : Controller
    {
        private readonly SkiJumpingContext _context;
        private readonly IJumperService _jumperService;

        public JumpersController(SkiJumpingContext context, IJumperService jumperService)
        {
            _context = context;
            _jumperService = jumperService;
        }

        // GET: Jumpers
        public async Task<IActionResult> Index()
        {
            var skiJumpingContext = _context.Jumpers.Include(j => j.Country);
            return View(await skiJumpingContext.ToListAsync());
        }

        public IActionResult GetStatisticJumper(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statisticJumper = _jumperService.GetStatisticJumper(id);

            return View(statisticJumper);
        }

        // GET: Jumpers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumper = await _context.Jumpers
                .Include(j => j.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jumper == null)
            {
                return NotFound();
            }

            return View(jumper);
        }

        // GET: Jumpers/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id");
            return View();
        }

        // POST: Jumpers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Birthday,Height,Weight,PersonalBest,CountryId")] Jumper jumper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jumper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", jumper.CountryId);
            return View(jumper);
        }

        // GET: Jumpers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumper = await _context.Jumpers.FindAsync(id);
            if (jumper == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", jumper.CountryId);
            return View(jumper);
        }

        // POST: Jumpers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Birthday,Height,Weight,PersonalBest,CountryId")] Jumper jumper)
        {
            if (id != jumper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jumper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JumperExists(jumper.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", jumper.CountryId);
            return View(jumper);
        }

        // GET: Jumpers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumper = await _context.Jumpers
                .Include(j => j.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jumper == null)
            {
                return NotFound();
            }

            return View(jumper);
        }

        // POST: Jumpers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jumper = await _context.Jumpers.FindAsync(id);
            _context.Jumpers.Remove(jumper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JumperExists(int id)
        {
            return _context.Jumpers.Any(e => e.Id == id);
        }
    }
}
