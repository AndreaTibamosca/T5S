﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T5S.Models;
using T5S.ModelsView;
using T5S.MoldelsView;

namespace T5S.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeografiumsController : ControllerBase
    {
        private readonly T5sContext _context;

        public GeografiumsController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/Geografiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeografiaMV>>> GetGeografia()
        {
          if (_context.Geografia == null)
          {
              return NotFound();
          }
            var query = from Geografium in await _context.Geografia.ToListAsync()
                        where Geografium.Estado == "Activo"
                        select new GeografiaMV
                        {
                            Id = Geografium.IdGeografia,
                            Ciudad = Geografium.Ciudad,
                            Pais = Geografium.Pais,
                            Estado = Geografium.Estado,

                        };
            return query.ToList();
        }

        // GET: api/Geografiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Geografium>> GetGeografium(int id)
        {
          if (_context.Geografia == null)
          {
              return NotFound();
          }
            var geografium = await _context.Geografia.FindAsync(id);

            if (geografium == null)
            {
                return NotFound();
            }

            return geografium;
        }

        // PUT: api/Geografiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeografium(int id, Geografium geografium)
        {
            if (id != geografium.IdGeografia)
            {
                return BadRequest();
            }

            _context.Entry(geografium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeografiumExists(id))
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

        // POST: api/Geografiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Geografium>> PostGeografium(Geografium geografium)
        {
          if (_context.Geografia == null)
          {
              return Problem("Entity set 'T5sContext.Geografia'  is null.");
          }
            _context.Geografia.Add(geografium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeografium", new { id = geografium.IdGeografia }, geografium);
        }

        // DELETE: api/Geografiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeografium(int id)
        {
            if (_context.Geografia == null)
            {
                return NotFound();
            }
            var geografium = await _context.Geografia.FindAsync(id);
            if (geografium == null)
            {
                return NotFound();
            }

            _context.Geografia.Remove(geografium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeografiumExists(int id)
        {
            return (_context.Geografia?.Any(e => e.IdGeografia == id)).GetValueOrDefault();
        }
    }
}
