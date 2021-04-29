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
    public class T02TerceroController : Controller
    {
        private readonly ModelContext _context;

        public T02TerceroController(ModelContext context)
        {
            _context = context;
        }

        // GET: T02Tercero
        public async Task<IActionResult> Index()
        {
            return View(await _context.T02Terceros.ToListAsync());
        }

        // GET: T02Tercero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t02Tercero = await _context.T02Terceros
                .FirstOrDefaultAsync(m => m.F02RowidTercero == id);
            if (t02Tercero == null)
            {
                return NotFound();
            }

            return View(t02Tercero);
        }

        // GET: T02Tercero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: T02Tercero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F02RowidTercero,F02IdDocumento,F02Nit,F02RazonSocial,F02Nombre1,F02Nombre2,F02Apellido1,F02Apellido2,F02TipoDocto,F02IndCliente,F02IndEmpleado,F02Telfeono,F02Direccion,F02Email,F02Estado,F02VlrPresupuesto,F02Notas")] T02Tercero t02Tercero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t02Tercero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(t02Tercero);
        }

        // GET: T02Tercero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t02Tercero = await _context.T02Terceros.FindAsync(id);
            if (t02Tercero == null)
            {
                return NotFound();
            }
            return View(t02Tercero);
        }

        // POST: T02Tercero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F02RowidTercero,F02IdDocumento,F02Nit,F02RazonSocial,F02Nombre1,F02Nombre2,F02Apellido1,F02Apellido2,F02TipoDocto,F02IndCliente,F02IndEmpleado,F02Telfeono,F02Direccion,F02Email,F02Estado,F02VlrPresupuesto,F02Notas")] T02Tercero t02Tercero)
        {
            if (id != t02Tercero.F02RowidTercero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t02Tercero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T02TerceroExists(t02Tercero.F02RowidTercero))
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
            return View(t02Tercero);
        }

        // GET: T02Tercero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t02Tercero = await _context.T02Terceros
                .FirstOrDefaultAsync(m => m.F02RowidTercero == id);
            if (t02Tercero == null)
            {
                return NotFound();
            }

            return View(t02Tercero);
        }

        // POST: T02Tercero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t02Tercero = await _context.T02Terceros.FindAsync(id);
            _context.T02Terceros.Remove(t02Tercero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T02TerceroExists(int id)
        {
            return _context.T02Terceros.Any(e => e.F02RowidTercero == id);
        }
    }
}
