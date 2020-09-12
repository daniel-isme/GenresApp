using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenresApp.Data;
using GenresApp.Models;

namespace GenresApp.Controllers
{
    public class SubGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubGenres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubGenre.Include(s => s.Parent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubGenres/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGenre = await _context.SubGenre
                .Include(s => s.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subGenre == null)
            {
                return NotFound();
            }

            subGenre.SubGenres = _context.SubGenre.Where(x => x.ParentId == subGenre.Id).Select(g => g).ToList();

            return View(subGenre);
        }

        // GET: SubGenres/Create
        public async Task<IActionResult> Create(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(new SubGenre() { Parent = genre, ParentId = genre.Id});
        }

        // POST: SubGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,Id,Name,Descriotion")] SubGenre subGenre)
        {
            if (ModelState.IsValid)
            {
                subGenre.Id = Guid.NewGuid();
                _context.Add(subGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Genres");
            }
            ViewData["ParentId"] = new SelectList(_context.Genre, "Id", "Name", subGenre.ParentId);
            return View(subGenre);
        }

        // GET: SubGenres/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGenre = await _context.SubGenre.FindAsync(id);
            if (subGenre == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Genre, "Id", "Name", subGenre.ParentId);
            return View(subGenre);
        }

        // POST: SubGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ParentId,Id,Name,Descriotion")] SubGenre subGenre)
        {
            if (id != subGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubGenreExists(subGenre.Id))
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
            ViewData["ParentId"] = new SelectList(_context.Genre, "Id", "Name", subGenre.ParentId);
            return View(subGenre);
        }

        // GET: SubGenres/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGenre = await _context.SubGenre
                .Include(s => s.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subGenre == null)
            {
                return NotFound();
            }

            return View(subGenre);
        }

        // POST: SubGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subGenre = await _context.SubGenre.FindAsync(id);
            _context.SubGenre.Remove(subGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubGenreExists(Guid id)
        {
            return _context.SubGenre.Any(e => e.Id == id);
        }
    }
}
