using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zadanie.Models;

namespace zadanie.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly MedievalCampusContext _context;

        public PublicationsController(MedievalCampusContext context)
        {
            _context = context;
        }

        // GET: Publications
        public async Task<IActionResult> Index()
        {
            var medievalCampusContext = _context.Publications.Include(p => p.Professor);
            return View(await medievalCampusContext.ToListAsync());
        }

        // GET: Publications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publications = await _context.Publications
                .Include(p => p.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publications == null)
            {
                return NotFound();
            }

            return View(publications);
        }

        // GET: Publications/Create
        public IActionResult Create()
        {
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "Id", "Id");
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DateOfRelease,Popularity,Subject,ProfessorId")] Publications publications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "Id", "Id", publications.ProfessorId);
            return View(publications);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publications = await _context.Publications.FindAsync(id);
            if (publications == null)
            {
                return NotFound();
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "Id", "Id", publications.ProfessorId);
            return View(publications);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DateOfRelease,Popularity,Subject,ProfessorId")] Publications publications)
        {
            if (id != publications.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationsExists(publications.Id))
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
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "Id", "Id", publications.ProfessorId);
            return View(publications);
        }

        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publications = await _context.Publications
                .Include(p => p.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publications == null)
            {
                return NotFound();
            }

            return View(publications);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publications = await _context.Publications.FindAsync(id);
            _context.Publications.Remove(publications);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationsExists(int id)
        {
            return _context.Publications.Any(e => e.Id == id);
        }
    }
}
