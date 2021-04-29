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
    public class T041MovtoFacturaController : Controller
    {
        private readonly ModelContext _context;

        public T041MovtoFacturaController(ModelContext context)
        {
            _context = context;
        }

        // GET: T041MovtoFactura
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.T041MovtoFacturas.Include(t => t.F041RowidDsctoNavigation).Include(t => t.F041RowidFacturaNavigation).Include(t => t.F041RowidItemNavigation).Include(t => t.F041RowidMantoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: T041MovtoFactura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t041MovtoFactura = await _context.T041MovtoFacturas
                .Include(t => t.F041RowidDsctoNavigation)
                .Include(t => t.F041RowidFacturaNavigation)
                .Include(t => t.F041RowidItemNavigation)
                .Include(t => t.F041RowidMantoNavigation)
                .FirstOrDefaultAsync(m => m.F041RowidMovto == id);
            if (t041MovtoFactura == null)
            {
                return NotFound();
            }

            return View(t041MovtoFactura);
        }

        // GET: T041MovtoFactura/Create
        public IActionResult Create()
        {
            ViewData["F041RowidDscto"] = new SelectList(_context.T06Descuentos, "F06RowidDescto", "F06RowidDescto");
            ViewData["F041RowidFactura"] = new SelectList(_context.T04Facturas, "F04RowidFactura", "F04RazonSocialCliente");
            ViewData["F041RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem");
            ViewData["F041RowidManto"] = new SelectList(_context.T05Mantenimientos, "F05RowidManto", "F05RowidManto");
            return View();
        }

        // POST: T041MovtoFactura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F041RowidFactura,F041RowidManto,F041RowidItem,F041RowidDscto,F041IdItem,F041DescripionItem,F041TipoItem,F041VlrBruto,F041VlrDesto,F041VlrImpto,F041VlrNeto,F041Notas,F041RowidMovto,F041CantItem")] T041MovtoFactura t041MovtoFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t041MovtoFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["F041RowidDscto"] = new SelectList(_context.T06Descuentos, "F06RowidDescto", "F06RowidDescto", t041MovtoFactura.F041RowidDscto);
            ViewData["F041RowidFactura"] = new SelectList(_context.T04Facturas, "F04RowidFactura", "F04RazonSocialCliente", t041MovtoFactura.F041RowidFactura);
            ViewData["F041RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t041MovtoFactura.F041RowidItem);
            ViewData["F041RowidManto"] = new SelectList(_context.T05Mantenimientos, "F05RowidManto", "F05RowidManto", t041MovtoFactura.F041RowidManto);
            return View(t041MovtoFactura);
        }

        // GET: T041MovtoFactura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t041MovtoFactura = await _context.T041MovtoFacturas.FindAsync(id);
            if (t041MovtoFactura == null)
            {
                return NotFound();
            }
            ViewData["F041RowidDscto"] = new SelectList(_context.T06Descuentos, "F06RowidDescto", "F06RowidDescto", t041MovtoFactura.F041RowidDscto);
            ViewData["F041RowidFactura"] = new SelectList(_context.T04Facturas, "F04RowidFactura", "F04RazonSocialCliente", t041MovtoFactura.F041RowidFactura);
            ViewData["F041RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t041MovtoFactura.F041RowidItem);
            ViewData["F041RowidManto"] = new SelectList(_context.T05Mantenimientos, "F05RowidManto", "F05RowidManto", t041MovtoFactura.F041RowidManto);
            return View(t041MovtoFactura);
        }

        // POST: T041MovtoFactura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F041RowidFactura,F041RowidManto,F041RowidItem,F041RowidDscto,F041IdItem,F041DescripionItem,F041TipoItem,F041VlrBruto,F041VlrDesto,F041VlrImpto,F041VlrNeto,F041Notas,F041RowidMovto,F041CantItem")] T041MovtoFactura t041MovtoFactura)
        {
            if (id != t041MovtoFactura.F041RowidMovto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t041MovtoFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T041MovtoFacturaExists(t041MovtoFactura.F041RowidMovto))
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
            ViewData["F041RowidDscto"] = new SelectList(_context.T06Descuentos, "F06RowidDescto", "F06RowidDescto", t041MovtoFactura.F041RowidDscto);
            ViewData["F041RowidFactura"] = new SelectList(_context.T04Facturas, "F04RowidFactura", "F04RazonSocialCliente", t041MovtoFactura.F041RowidFactura);
            ViewData["F041RowidItem"] = new SelectList(_context.T01Items, "F01RowidItem", "F01DescripionItem", t041MovtoFactura.F041RowidItem);
            ViewData["F041RowidManto"] = new SelectList(_context.T05Mantenimientos, "F05RowidManto", "F05RowidManto", t041MovtoFactura.F041RowidManto);
            return View(t041MovtoFactura);
        }

        // GET: T041MovtoFactura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t041MovtoFactura = await _context.T041MovtoFacturas
                .Include(t => t.F041RowidDsctoNavigation)
                .Include(t => t.F041RowidFacturaNavigation)
                .Include(t => t.F041RowidItemNavigation)
                .Include(t => t.F041RowidMantoNavigation)
                .FirstOrDefaultAsync(m => m.F041RowidMovto == id);
            if (t041MovtoFactura == null)
            {
                return NotFound();
            }

            return View(t041MovtoFactura);
        }

        // POST: T041MovtoFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t041MovtoFactura = await _context.T041MovtoFacturas.FindAsync(id);
            _context.T041MovtoFacturas.Remove(t041MovtoFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T041MovtoFacturaExists(int id)
        {
            return _context.T041MovtoFacturas.Any(e => e.F041RowidMovto == id);
        }
    }
}
