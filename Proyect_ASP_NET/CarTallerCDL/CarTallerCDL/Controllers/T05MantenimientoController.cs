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
    public class T05MantenimientoController : Controller
    {
        private readonly ModelContext _context;

        public T05MantenimientoController(ModelContext context)
        {
            _context = context;
        }

        // GET: T05Mantenimiento
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.T05Mantenimientos.Include(t => t.F05RowidTerceroClienteNavigation).Include(t => t.F05RowidVehiculoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: T05Mantenimiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t05Mantenimiento = await _context.T05Mantenimientos
                .Include(t => t.F05RowidTerceroClienteNavigation)
                .Include(t => t.F05RowidVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.F05RowidManto == id);
            if (t05Mantenimiento == null)
            {
                return NotFound();
            }

            return View(t05Mantenimiento);
        }

        // GET: T05Mantenimiento/Create
        public IActionResult Create()
        {
            ViewData["F05RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1");
            ViewData["F05RowidVehiculo"] = new SelectList(_context.T03Vehiculos, "F03RowidVehivulo", "F03Descripcion");
            return View();
        }

        // POST: T05Mantenimiento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F05RowidManto,F05RowidVehiculo,F05RowidTerceroCliente,F05EstadoManto,F05Foto,F05Notas,F05IdMantto,F05VlrMin,F05VlrMax")] T05Mantenimiento t05Mantenimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t05Mantenimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["F05RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t05Mantenimiento.F05RowidTerceroCliente);
            ViewData["F05RowidVehiculo"] = new SelectList(_context.T03Vehiculos, "F03RowidVehivulo", "F03Descripcion", t05Mantenimiento.F05RowidVehiculo);
            return View(t05Mantenimiento);
        }

        // GET: T05Mantenimiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t05Mantenimiento = await _context.T05Mantenimientos.FindAsync(id);
            if (t05Mantenimiento == null)
            {
                return NotFound();
            }
            ViewData["F05RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t05Mantenimiento.F05RowidTerceroCliente);
            ViewData["F05RowidVehiculo"] = new SelectList(_context.T03Vehiculos, "F03RowidVehivulo", "F03Descripcion", t05Mantenimiento.F05RowidVehiculo);
            return View(t05Mantenimiento);
        }

        // POST: T05Mantenimiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F05RowidManto,F05RowidVehiculo,F05RowidTerceroCliente,F05EstadoManto,F05Foto,F05Notas,F05IdMantto,F05VlrMin,F05VlrMax")] T05Mantenimiento t05Mantenimiento)
        {
            if (id != t05Mantenimiento.F05RowidManto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t05Mantenimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T05MantenimientoExists(t05Mantenimiento.F05RowidManto))
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
            ViewData["F05RowidTerceroCliente"] = new SelectList(_context.T02Terceros, "F02RowidTercero", "F02Apellido1", t05Mantenimiento.F05RowidTerceroCliente);
            ViewData["F05RowidVehiculo"] = new SelectList(_context.T03Vehiculos, "F03RowidVehivulo", "F03Descripcion", t05Mantenimiento.F05RowidVehiculo);
            return View(t05Mantenimiento);
        }

        // GET: T05Mantenimiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t05Mantenimiento = await _context.T05Mantenimientos
                .Include(t => t.F05RowidTerceroClienteNavigation)
                .Include(t => t.F05RowidVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.F05RowidManto == id);
            if (t05Mantenimiento == null)
            {
                return NotFound();
            }

            return View(t05Mantenimiento);
        }

        // POST: T05Mantenimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t05Mantenimiento = await _context.T05Mantenimientos.FindAsync(id);
            _context.T05Mantenimientos.Remove(t05Mantenimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T05MantenimientoExists(int id)
        {
            return _context.T05Mantenimientos.Any(e => e.F05RowidManto == id);
        }
    }
}
