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
    public class EstudiantesController : ControllerBase
    {
        private readonly T5sContext _context;

        public EstudiantesController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/Estudiantess

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudiantesMV>>> GetEstudiantes()
        {
            var estudiantes = await _context.Estudiantes
                .Select(estudiante => new EstudiantesMV
                {
                    id = estudiante.IdEstudiante,
                    Nombre = estudiante.NombreEst,
                    Apellido = estudiante.ApellidoEst,
                    TipoDocumento = estudiante.TipoDocumentoEst,
                    Numero = estudiante.NumeroDocumentoEst,
                    Estado = estudiante.Estado,
                    Celular = estudiante.CelularEst,
                    Correo = estudiante.CorreoEst,
                })
                .ToListAsync();

            if (estudiantes == null || estudiantes.Count == 0)
            {
                return NotFound();
            }

            return estudiantes;
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
          if (_context.Estudiantes == null)
          {
              return NotFound();
          }
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // PUT: api/Estudiantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.IdEstudiante)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
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

        // POST: api/Estudiantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
          if (_context.Estudiantes == null)
          {
              return Problem("Entity set 'T5sContext.Estudiantes'  is null.");
          }
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiante", new { id = estudiante.IdEstudiante }, estudiante);
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            if (_context.Estudiantes == null)
            {
                return NotFound();
            }
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return (_context.Estudiantes?.Any(e => e.IdEstudiante == id)).GetValueOrDefault();
        }
    }
}
