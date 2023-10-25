using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T5S.Models;
using T5S.ModelViews;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace T5S.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly T5sContext _context;

        public LoginsController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginMV>>> GetLogins()
        {
            if (_context.Logins == null)
            {
                return NotFound();
            }
            var query = from Login in await _context.Logins.ToListAsync()
                        join Estudiantes in await _context.Estudiantes.ToListAsync() on Login.IdLogin equals Estudiantes.IdLogin
                        select new LoginMV
                        {
                            Nombre = Estudiantes.NombreEst,
                            Nombreusuario = Login.User,
                            Password = Login.Password,
                        };
            return query.ToList();
                        }

            //return await _context.Logins.ToListAsync();
        

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            var login = await _context.Logins.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Logins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.IdLogin)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
          if (_context.Logins == null)
          {
              return Problem("Entity set 'T5sContext.Logins'  is null.");
          }
            _context.Logins.Add(login);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginExists(login.IdLogin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogin", new { id = login.IdLogin }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            if (_context.Logins == null)
            {
                return NotFound();
            }
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(int id)
        {
            return (_context.Logins?.Any(e => e.IdLogin == id)).GetValueOrDefault();
        }
    }
}
