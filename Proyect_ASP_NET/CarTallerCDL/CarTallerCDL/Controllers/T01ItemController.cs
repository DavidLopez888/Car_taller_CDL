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
    public class T01ItemController : Controller
    {
        private readonly ModelContext _context;

        public T01ItemController(ModelContext context)
        {
            _context = context;
        }

        // GET: T01Item
        public async Task<IActionResult> Index()
        {
            return View(await _context.T01Items.ToListAsync());
        }

        // GET: T01Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var t01Item = await _context.T01Items
            //  .FirstOrDefaultAsync(m => m.F01RowidItem == id);
            var t01Item = (from item in _context.T01Items
                           where item.F01RowidItem == id
                           select item).FirstOrDefault();
            if (t01Item == null)
            {
                return NotFound();
            }

            return View(t01Item);
        }

        // GET: T01Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: T01Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("F01RowidItem,F01IdItem,F01DescripionItem,F01TipoItem,F01Notas")] T01Item t01Item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t01Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(t01Item);
        }

        // GET: T01Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t01Item = await _context.T01Items.FindAsync(id);
            if (t01Item == null)
            {
                return NotFound();
            }
            return View(t01Item);
        }

        // POST: T01Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("F01RowidItem,F01IdItem,F01DescripionItem,F01TipoItem,F01Notas")] T01Item t01Item)
        {
            if (id != t01Item.F01RowidItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t01Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T01ItemExists(t01Item.F01RowidItem))
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
            return View(t01Item);
        }

        // GET: T01Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t01Item = await _context.T01Items
                .FirstOrDefaultAsync(m => m.F01RowidItem == id);
            if (t01Item == null)
            {
                return NotFound();
            }

            return View(t01Item);
        }

        // POST: T01Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t01Item = await _context.T01Items.FindAsync(id);
            _context.T01Items.Remove(t01Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T01ItemExists(int id)
        {
            return _context.T01Items.Any(e => e.F01RowidItem == id);
        }
    }
}
