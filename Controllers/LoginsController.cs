﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T5S.Models;
using T5S.ModelViews;

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

        [HttpGet("{User},{Password}")]
        public async Task<ActionResult<LoginMV>> Login(string User, string Password)
        {
            var login = await _context.Logins.FirstOrDefaultAsync(x => x.User.Equals(User) && x.Password.Equals(Password));
            if (login == null)
            {
                return NotFound();
            }

            var loginMV = new LoginMV
            {
                Usuario = login.User,
                Password = login.Password,

                // Datos del estudiantes
                Estado = login.Estado,

            };

            return Ok(loginMV);
        }

        // GET: api/Logins

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginMV>>> GetLogins()
        {
            var logins = await _context.Logins
                .Select(login => new LoginMV
                {
                    id = login.IdLogin,
                    Usuario = login.User,
                    Password = login.Password,
                    Estado = login.Estado
                })
                .ToListAsync();

            if (logins == null || logins.Count == 0)
            {
                return NotFound();
            }

            return logins;
        }

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
       
        [HttpPost("{User},{Password}")]
 public async Task<ActionResult<Login>> PostLogin(string User, string Password)
        {
            var register = await _context.Logins.FirstOrDefaultAsync(x => x.User.Equals(User) && x.Password.Equals(Password));

            if (register != null)
            {
                return Conflict(); // Conflict si ya existe un login con las mismas credenciales
            }

            // Obtener el último IdLogin de la base de datos
            int _ultimoId = _context.Logins.OrderByDescending(u => u.IdLogin).FirstOrDefault()?.IdLogin ?? 0;

            // Crear un nuevo login con el próximo IdLogin
            var loginMV = new Login
            {
                IdLogin = _ultimoId + 1,
                User = User,
                Password = Password,
                Estado = "Activo",
                IdEstudiante = null
            };

            // Agregar el nuevo login al contexto y guardar cambios
            _context.Logins.Add(loginMV);
 
            // Asegurarse de que haya cambios antes de intentar obtener el IdLogin
            await _context.SaveChangesAsync();

            // Obtener el IdLogin después de guardar cambios

            return Ok(loginMV);
        }

        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
          if (_context.Logins == null)
          {
              return Problem("Entity set 'T5sContext.Logins'  is null.");
          }
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

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
