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
    public class TutorsController : ControllerBase
    {
        private readonly T5sContext _context;

        public TutorsController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/Tutors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutors()
        {
          if (_context.Tutors == null)
          {
              return NotFound();
          }
            return await _context.Tutors.ToListAsync();
        }

        // GET: api/Tutors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(int id)
        {
          if (_context.Tutors == null)
          {
              return NotFound();
          }
            var tutor = await _context.Tutors.FindAsync(id);

            if (tutor == null)
            {
                return NotFound();
            }

            return tutor;
        }

        // PUT: api/Tutors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor(int id, Tutor tutor)
        {
            if (id != tutor.IdTutor)
            {
                return BadRequest();
            }

            _context.Entry(tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
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

        // POST: api/Tutors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tutor>> PostTutor(Tutor tutor)
        {
          if (_context.Tutors == null)
          {
              return Problem("Entity set 'T5sContext.Tutors'  is null.");
          }
            _context.Tutors.Add(tutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutor", new { id = tutor.IdTutor }, tutor);
        }

        // DELETE: api/Tutors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            if (_context.Tutors == null)
            {
                return NotFound();
            }
            var tutor = await _context.Tutors.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutors.Remove(tutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TutorExists(int id)
        {
            return (_context.Tutors?.Any(e => e.IdTutor == id)).GetValueOrDefault();
        }
    }
}
