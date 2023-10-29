using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T5S.Models;

namespace T5S.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorMateriumsController : ControllerBase
    {
        private readonly T5sContext _context;

        public TutorMateriumsController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/TutorMateriums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TutorMaterium>>> GetTutorMateria()
        {
            if (_context.TutorMateria == null)
            {
                return NotFound();
            }
            return await _context.TutorMateria.ToListAsync();
        }

        // GET: api/TutorMateriums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TutorMaterium>> GetTutorMaterium(int id)
        {
            if (_context.TutorMateria == null)
            {
                return NotFound();
            }
            var tutorMaterium = await _context.TutorMateria.FindAsync(id);

            if (tutorMaterium == null)
            {
                return NotFound();
            }

            return tutorMaterium;
        }

        // PUT: api/TutorMateriums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutorMaterium(int id, TutorMaterium tutorMaterium)
        {
            if (id != tutorMaterium.IdTutorMateria)
            {
                return BadRequest();
            }

            _context.Entry(tutorMaterium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorMateriumExists(id))
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

        // POST: api/TutorMateriums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TutorMaterium>> PostTutorMaterium(TutorMaterium tutorMaterium)
        {
            if (_context.TutorMateria == null)
            {
                return Problem("Entity set 'T5sContext.TutorMateria'  is null.");
            }
            _context.TutorMateria.Add(tutorMaterium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TutorMateriumExists(tutorMaterium.IdTutorMateria))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTutorMaterium", new { id = tutorMaterium.IdTutorMateria }, tutorMaterium);
        }

        // DELETE: api/TutorMateriums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutorMaterium(int id)
        {
            if (_context.TutorMateria == null)
            {
                return NotFound();
            }
            var tutorMaterium = await _context.TutorMateria.FindAsync(id);
            if (tutorMaterium == null)
            {
                return NotFound();
            }

            _context.TutorMateria.Remove(tutorMaterium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TutorMateriumExists(int id)
        {
            return (_context.TutorMateria?.Any(e => e.IdTutorMateria == id)).GetValueOrDefault();
        }
    }
}