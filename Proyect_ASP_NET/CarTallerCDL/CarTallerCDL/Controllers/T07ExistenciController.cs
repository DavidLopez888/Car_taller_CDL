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
    public class T07ExistenciController : Controller
    {
        private readonly ModelContext _context;

        public T07ExistenciController(ModelContext context)
        {
            _context = context;
        }

        // GET: T07Existenci
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.T07Existencis.Include(t => t.F07RowidItemNavigation).Include(t => t.F07RowidTiendaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: T07Existenci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t07Existenci = await _context.T07Existencis
                .Include(t => t.F07RowidItemNavigation)
                .Include(t => t.F07RowidTiendaNavigation)
                .FirstOrDefaultAsync(m => m.F07RowidItem == id);
            if (t07Existenci == null)
            {
                return NotFound();
            }

            return View(t07Existenci);
        }

        // GET: T07Existenci/Create
        public IActionResult Create()
        {
            ViewData["F07RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem");
            ViewData["F07RowidTienda"] = new SelectList(_context.T08Tienda, "F08RowidTienda", "F08NombreTienda");
            return View();
        }

        // POST: T07Existenci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F07RowidItem,F07CantExistencia,F07RowidTienda")] T07Existenci t07Existenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t07Existenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["F07RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t07Existenci.F07RowidItem);
            ViewData["F07RowidTienda"] = new SelectList(_context.T08Tienda, "F08RowidTienda", "F08NombreTienda", t07Existenci.F07RowidTienda);
            return View(t07Existenci);
        }

        // GET: T07Existenci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t07Existenci = await _context.T07Existencis.FindAsync(id);
            if (t07Existenci == null)
            {
                return NotFound();
            }
            ViewData["F07RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t07Existenci.F07RowidItem);
            ViewData["F07RowidTienda"] = new SelectList(_context.T08Tienda, "F08RowidTienda", "F08NombreTienda", t07Existenci.F07RowidTienda);
            return View(t07Existenci);
        }

        // POST: T07Existenci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F07RowidItem,F07CantExistencia,F07RowidTienda")] T07Existenci t07Existenci)
        {
            if (id != t07Existenci.F07RowidItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t07Existenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T07ExistenciExists(t07Existenci.F07RowidItem))
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
            ViewData["F07RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t07Existenci.F07RowidItem);
            ViewData["F07RowidTienda"] = new SelectList(_context.T08Tienda, "F08RowidTienda", "F08NombreTienda", t07Existenci.F07RowidTienda);
            return View(t07Existenci);
        }

        // GET: T07Existenci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t07Existenci = await _context.T07Existencis
                .Include(t => t.F07RowidItemNavigation)
                .Include(t => t.F07RowidTiendaNavigation)
                .FirstOrDefaultAsync(m => m.F07RowidItem == id);
            if (t07Existenci == null)
            {
                return NotFound();
            }

            return View(t07Existenci);
        }

        // POST: T07Existenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t07Existenci = await _context.T07Existencis.FindAsync(id);
            _context.T07Existencis.Remove(t07Existenci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T07ExistenciExists(int id)
        {
            return _context.T07Existencis.Any(e => e.F07RowidItem == id);
        }
    }
}
