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
    public class T03VehiculoController : Controller
    {
        private readonly ModelContext _context;

        public T03VehiculoController(ModelContext context)
        {
            _context = context;
        }

        // GET: T03Vehiculo
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.T03Vehiculos.Include(t => t.F03RowidTerceroNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: T03Vehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t03Vehiculo = await _context.T03Vehiculos
                .Include(t => t.F03RowidTerceroNavigation)
                .FirstOrDefaultAsync(m => m.F03RowidVehivulo == id);
            if (t03Vehiculo == null)
            {
                return NotFound();
            }

            return View(t03Vehiculo);
        }

        // GET: T03Vehiculo/Create
        public IActionResult Create()
        {
            ViewData["F03RowidTercero"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1");
            return View();
        }

        // POST: T03Vehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F03RowidVehivulo,F03RowidTercero,F03Placa,F03Descripcion,F03Notas")] T03Vehiculo t03Vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t03Vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["F03RowidTercero"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t03Vehiculo.F03RowidTercero);
            return View(t03Vehiculo);
        }

        // GET: T03Vehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t03Vehiculo = await _context.T03Vehiculos.FindAsync(id);
            if (t03Vehiculo == null)
            {
                return NotFound();
            }
            ViewData["F03RowidTercero"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t03Vehiculo.F03RowidTercero);
            return View(t03Vehiculo);
        }

        // POST: T03Vehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F03RowidVehivulo,F03RowidTercero,F03Placa,F03Descripcion,F03Notas")] T03Vehiculo t03Vehiculo)
        {
            if (id != t03Vehiculo.F03RowidVehivulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t03Vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T03VehiculoExists(t03Vehiculo.F03RowidVehivulo))
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
            ViewData["F03RowidTercero"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t03Vehiculo.F03RowidTercero);
            return View(t03Vehiculo);
        }

        // GET: T03Vehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t03Vehiculo = await _context.T03Vehiculos
                .Include(t => t.F03RowidTerceroNavigation)
                .FirstOrDefaultAsync(m => m.F03RowidVehivulo == id);
            if (t03Vehiculo == null)
            {
                return NotFound();
            }

            return View(t03Vehiculo);
        }

        // POST: T03Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t03Vehiculo = await _context.T03Vehiculos.FindAsync(id);
            _context.T03Vehiculos.Remove(t03Vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T03VehiculoExists(int id)
        {
            return _context.T03Vehiculos.Any(e => e.F03RowidVehivulo == id);
        }
    }
}
