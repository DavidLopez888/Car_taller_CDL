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
    public class T06DescuentoController : Controller
    {
        private readonly ModelContext _context;

        public T06DescuentoController(ModelContext context)
        {
            _context = context;
        }

        // GET: T06Descuento
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.T06Descuentos.Include(t => t.F06RowidItemNavigation).Include(t => t.F06RowidTerceroClienteNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: T06Descuento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t06Descuento = await _context.T06Descuentos
                .Include(t => t.F06RowidItemNavigation)
                .Include(t => t.F06RowidTerceroClienteNavigation)
                .FirstOrDefaultAsync(m => m.F06RowidDescto == id);
            if (t06Descuento == null)
            {
                return NotFound();
            }

            return View(t06Descuento);
        }

        // GET: T06Descuento/Create
        public IActionResult Create()
        {
            ViewData["F06RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem");
            ViewData["F06RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1");
            return View();
        }

        // POST: T06Descuento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F06RowidDescto,F06RowidItem,F06RowidTerceroCliente,F06Estado,F06VlrMin,F06VlrMax")] T06Descuento t06Descuento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t06Descuento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["F06RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t06Descuento.F06RowidItem);
            ViewData["F06RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t06Descuento.F06RowidTerceroCliente);
            return View(t06Descuento);
        }

        // GET: T06Descuento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t06Descuento = await _context.T06Descuentos.FindAsync(id);
            if (t06Descuento == null)
            {
                return NotFound();
            }
            ViewData["F06RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t06Descuento.F06RowidItem);
            ViewData["F06RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t06Descuento.F06RowidTerceroCliente);
            return View(t06Descuento);
        }

        // POST: T06Descuento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F06RowidDescto,F06RowidItem,F06RowidTerceroCliente,F06Estado,F06VlrMin,F06VlrMax")] T06Descuento t06Descuento)
        {
            if (id != t06Descuento.F06RowidDescto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t06Descuento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T06DescuentoExists(t06Descuento.F06RowidDescto))
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
            ViewData["F06RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t06Descuento.F06RowidItem);
            ViewData["F06RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t06Descuento.F06RowidTerceroCliente);
            return View(t06Descuento);
        }

        // GET: T06Descuento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t06Descuento = await _context.T06Descuentos
                .Include(t => t.F06RowidItemNavigation)
                .Include(t => t.F06RowidTerceroClienteNavigation)
                .FirstOrDefaultAsync(m => m.F06RowidDescto == id);
            if (t06Descuento == null)
            {
                return NotFound();
            }

            return View(t06Descuento);
        }

        // POST: T06Descuento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t06Descuento = await _context.T06Descuentos.FindAsync(id);
            _context.T06Descuentos.Remove(t06Descuento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T06DescuentoExists(int id)
        {
            return _context.T06Descuentos.Any(e => e.F06RowidDescto == id);
        }
    }
}
