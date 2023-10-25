using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T5S.Models;
using T5S.MoldelsView;

namespace T5S.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendariosController : ControllerBase
    {
        private readonly T5sContext _context;

        public CalendariosController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/Calendarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarioMV>>> GetCalendarios()
        {
            if (_context.Calendarios == null)
            {
                return NotFound();
            }
            var query = from Calendario in await _context.Calendarios.ToListAsync()
                        join ResevarTutorium in await _context.ResevarTutoria.ToListAsync() on Calendario.IdCalendario equals ResevarTutorium.IdCalendario
                        select new CalendarioMV
                        {
                            Id = Calendario.IdCalendario,
                            Fecha = Calendario.FechaCalendario,
                            Descripcion = Calendario.DescripcionCalendario,
                            Barrio = ResevarTutorium.Barrio,
                            TipoTutoria = ResevarTutorium.TipoTutoria,

                        };
            return query.ToList();

            //return await _context.Calendarios.ToListAsync();
        }

        // GET: api/Calendarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calendario>> GetCalendario(int id)
        {
            if (_context.Calendarios == null)
            {
                return NotFound();
            }
            var calendario = await _context.Calendarios.FindAsync(id);

            if (calendario == null)
            {
                return NotFound();
            }

            return calendario;
        }

        // PUT: api/Calendarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendario(int id, Calendario calendario)
        {
            if (id != calendario.IdCalendario)
            {
                return BadRequest();
            }

            _context.Entry(calendario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Calendarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calendario>> PostCalendario(Calendario calendario)
        {
            if (_context.Calendarios == null)
            {
                return Problem("Entity set 'T5sContext.Calendarios'  is null.");
            }
            _context.Calendarios.Add(calendario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CalendarioExists(calendario.IdCalendario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCalendario", new { id = calendario.IdCalendario }, calendario);
        }

        // DELETE: api/Calendarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendario(int id)
        {
            if (_context.Calendarios == null)
            {
                return NotFound();
            }
            var calendario = await _context.Calendarios.FindAsync(id);
            if (calendario == null)
            {
                return NotFound();
            }

            _context.Calendarios.Remove(calendario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarioExists(int id)
        {
            return (_context.Calendarios?.Any(e => e.IdCalendario == id)).GetValueOrDefault();
        }
    }
}
