using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T5S.Models;
using T5S.ModelsView;

namespace T5S.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResevarTutoriumsController : ControllerBase
    {
        private readonly T5sContext _context;

        public ResevarTutoriumsController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/ResevarTutoriums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaTutoriaMV>>> GetResevarTutoria()
        {
          if (_context.ResevarTutoria == null)
          {
              return NotFound();
          }
            var query = from ResevarTutorium in await _context.ResevarTutoria.ToListAsync()
                        where ResevarTutorium.Estado == 1

                        select new ReservaTutoriaMV
                        {
                            Id = ResevarTutorium.IdReserva,
                            FechaTutoria = ResevarTutorium.FechaTutoria,
                            HoraTutoria = ResevarTutorium.HoraTutoria,
                            CantidadHoras = ResevarTutorium.CantidadHoras,
                            Localidad = ResevarTutorium.Localidad,
                            Barrio = ResevarTutorium.Barrio,
                            DireccionTutoria = ResevarTutorium.DireccionTutoria,
                            TipoTutoria = ResevarTutorium.TipoTutoria,
                            DescripcionTutoria = ResevarTutorium.DescripcionTutoria,
                            Estado = ResevarTutorium.Estado,


                        };
            return query.ToList();
        }

        // GET: api/ResevarTutoriums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResevarTutorium>> GetResevarTutorium(int id)
        {
          if (_context.ResevarTutoria == null)
          {
              return NotFound();
          }
            var resevarTutorium = await _context.ResevarTutoria.FindAsync(id);

            if (resevarTutorium == null)
            {
                return NotFound();
            }

            return resevarTutorium;
        }

        // PUT: api/ResevarTutoriums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResevarTutorium(int id, ResevarTutorium resevarTutorium)
        {
            if (id != resevarTutorium.IdReserva)
            {
                return BadRequest();
            }

            _context.Entry(resevarTutorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResevarTutoriumExists(id))
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

        // POST: api/ResevarTutoriums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResevarTutorium>> PostResevarTutorium(ResevarTutorium resevarTutorium)
        {
          if (_context.ResevarTutoria == null)
          {
              return Problem("Entity set 'T5sContext.ResevarTutoria'  is null.");
          }
            _context.ResevarTutoria.Add(resevarTutorium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResevarTutorium", new { id = resevarTutorium.IdReserva }, resevarTutorium);
        }

        // DELETE: api/ResevarTutoriums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResevarTutorium(int id)
        {
            if (_context.ResevarTutoria == null)
            {
                return NotFound();
            }
            var resevarTutorium = await _context.ResevarTutoria.FindAsync(id);
            if (resevarTutorium == null)
            {
                return NotFound();
            }

            _context.ResevarTutoria.Remove(resevarTutorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResevarTutoriumExists(int id)
        {
            return (_context.ResevarTutoria?.Any(e => e.IdReserva == id)).GetValueOrDefault();
        }
    }
}
