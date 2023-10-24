using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T5S.Models;

namespace T5S.Controllers
{
    public class CalendariosController : Controller
    {
        private readonly T5sContext _context;

        public CalendariosController(T5sContext context)
        {
            _context = context;
        }

        // GET: Calendarios
        public async Task<IActionResult> Index()
        {
              return _context.Calendarios != null ? 
                          View(await _context.Calendarios.ToListAsync()) :
                          Problem("Entity set 'T5sContext.Calendarios'  is null.");
        }

        // GET: Calendarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calendarios == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios
                .FirstOrDefaultAsync(m => m.IdCalendario == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        // GET: Calendarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calendarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalendario,FechaCalendario,DescripcionCalendario")] Calendario calendario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendario);
        }

        // GET: Calendarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calendarios == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios.FindAsync(id);
            if (calendario == null)
            {
                return NotFound();
            }
            return View(calendario);
        }

        // POST: Calendarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalendario,FechaCalendario,DescripcionCalendario")] Calendario calendario)
        {
            if (id != calendario.IdCalendario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarioExists(calendario.IdCalendario))
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
            return View(calendario);
        }

        // GET: Calendarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calendarios == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios
                .FirstOrDefaultAsync(m => m.IdCalendario == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        // POST: Calendarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calendarios == null)
            {
                return Problem("Entity set 'T5sContext.Calendarios'  is null.");
            }
            var calendario = await _context.Calendarios.FindAsync(id);
            if (calendario != null)
            {
                _context.Calendarios.Remove(calendario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarioExists(int id)
        {
          return (_context.Calendarios?.Any(e => e.IdCalendario == id)).GetValueOrDefault();
        }
    }
}
