using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarTallerCDL;

namespace CarTallerCDL.Controllers
{
    public class T08TiendumController : Controller
    {
        private readonly ModelContext _context;

        public T08TiendumController(ModelContext context)
        {
            _context = context;
        }

        // GET: T08Tiendum
        public async Task<IActionResult> Index()
        {
            return View(await _context.T08Tienda.ToListAsync());
        }

        // GET: T08Tiendum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t08Tiendum = await _context.T08Tienda
                .FirstOrDefaultAsync(m => m.F08RowidTienda == id);
            if (t08Tiendum == null)
            {
                return NotFound();
            }

            return View(t08Tiendum);
        }

        // GET: T08Tiendum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: T08Tiendum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F08RowidTienda,F08NombreTienda,F08Ciudad")] T08Tiendum t08Tiendum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t08Tiendum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(t08Tiendum);
        }

        // GET: T08Tiendum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t08Tiendum = await _context.T08Tienda.FindAsync(id);
            if (t08Tiendum == null)
            {
                return NotFound();
            }
            return View(t08Tiendum);
        }

        // POST: T08Tiendum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F08RowidTienda,F08NombreTienda,F08Ciudad")] T08Tiendum t08Tiendum)
        {
            if (id != t08Tiendum.F08RowidTienda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t08Tiendum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T08TiendumExists(t08Tiendum.F08RowidTienda))
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
            return View(t08Tiendum);
        }

        // GET: T08Tiendum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t08Tiendum = await _context.T08Tienda
                .FirstOrDefaultAsync(m => m.F08RowidTienda == id);
            if (t08Tiendum == null)
            {
                return NotFound();
            }

            return View(t08Tiendum);
        }

        // POST: T08Tiendum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t08Tiendum = await _context.T08Tienda.FindAsync(id);
            _context.T08Tienda.Remove(t08Tiendum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T08TiendumExists(int id)
        {
            return _context.T08Tienda.Any(e => e.F08RowidTienda == id);
        }
    }
}
