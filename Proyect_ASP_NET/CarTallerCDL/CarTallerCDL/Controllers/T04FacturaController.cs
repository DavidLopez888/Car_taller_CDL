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
    public class T04FacturaController : Controller
    {
        private readonly ModelContext _context;

        public T04FacturaController(ModelContext context)
        {
            _context = context;
        }

        // GET: T04Factura
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.T04Facturas.Include(t => t.F04RowidTerceroClienteNavigation).Include(t => t.F04RowidTerceroMecanicoNavigation).Include(t => t.F04RowidTiendaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: T04Factura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t04Factura = await _context.T04Facturas
                .Include(t => t.F04RowidTerceroClienteNavigation)
                .Include(t => t.F04RowidTerceroMecanicoNavigation)
                .Include(t => t.F04RowidTiendaNavigation)
                .FirstOrDefaultAsync(m => m.F04RowidFactura == id);
            if (t04Factura == null)
            {
                return NotFound();
            }

            return View(t04Factura);
        }

        // GET: T04Factura/Create
        public IActionResult Create()
        {
            ViewData["F04RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1");
            ViewData["F04RowidTerceroMecanico"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1");
            ViewData["F04RowidTienda"] = new SelectList(_context.T08Tienda, "F08RowidTienda", "F08NombreTienda");
            return View();
        }

        // POST: T04Factura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F04RowidFactura,F04ConsecDocto,F04RowidTerceroCliente,F04RowidTerceroMecanico,F04RazonSocialCliente,F04RazonSocialMecanico,F04Notas,F04FechaDocto,F04VlrBruto,F04VlrDesto,F04VlrImpto,F04VlrNeto,F04RowidTienda")] T04Factura t04Factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t04Factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["F04RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t04Factura.F04RowidTerceroCliente);
            ViewData["F04RowidTerceroMecanico"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t04Factura.F04RowidTerceroMecanico);
            ViewData["F04RowidTienda"] = new SelectList(_context.T08Tienda, "F08RowidTienda", "F08NombreTienda", t04Factura.F04RowidTienda);
            return View(t04Factura);
        }

        // GET: T04Factura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t04Factura = await _context.T04Facturas.FindAsync(id);
            if (t04Factura == null)
            {
                return NotFound();
            }
            ViewData["F04RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t04Factura.F04RowidTerceroCliente);
            ViewData["F04RowidTerceroMecanico"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t04Factura.F04RowidTerceroMecanico);
            ViewData["F04RowidTienda"] = new SelectList(_context.T08Tienda, "F08RowidTienda", "F08NombreTienda", t04Factura.F04RowidTienda);
            return View(t04Factura);
        }

        // POST: T04Factura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F04RowidFactura,F04ConsecDocto,F04RowidTerceroCliente,F04RowidTerceroMecanico,F04RazonSocialCliente,F04RazonSocialMecanico,F04Notas,F04FechaDocto,F04VlrBruto,F04VlrDesto,F04VlrImpto,F04VlrNeto,F04RowidTienda")] T04Factura t04Factura)
        {
            if (id != t04Factura.F04RowidFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t04Factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T04FacturaExists(t04Factura.F04RowidFactura))
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
            ViewData["F04RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t04Factura.F04RowidTerceroCliente);
            ViewData["F04RowidTerceroMecanico"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t04Factura.F04RowidTerceroMecanico);
            ViewData["F04RowidTienda"] = new SelectList(_context.T08Tienda, "F08RowidTienda", "F08NombreTienda", t04Factura.F04RowidTienda);
            return View(t04Factura);
        }

        // GET: T04Factura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t04Factura = await _context.T04Facturas
                .Include(t => t.F04RowidTerceroClienteNavigation)
                .Include(t => t.F04RowidTerceroMecanicoNavigation)
                .Include(t => t.F04RowidTiendaNavigation)
                .FirstOrDefaultAsync(m => m.F04RowidFactura == id);
            if (t04Factura == null)
            {
                return NotFound();
            }

            return View(t04Factura);
        }

        // POST: T04Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t04Factura = await _context.T04Facturas.FindAsync(id);
            _context.T04Facturas.Remove(t04Factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T04FacturaExists(int id)
        {
            return _context.T04Facturas.Any(e => e.F04RowidFactura == id);
        }
    }
}
