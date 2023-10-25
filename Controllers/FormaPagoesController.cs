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
    public class FormaPagoesController : ControllerBase
    {
        private readonly T5sContext _context;

        public FormaPagoesController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/FormaPagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormaPagoMV>>> GetFormaPagos()
        {
            if (_context.FormaPagos == null)
            {
                return NotFound();
            }

            var query = from FormaPago in await _context.FormaPagos.ToListAsync()
                        join ResevarTutorium in await _context.ResevarTutoria.ToListAsync() on FormaPago.IdPago equals ResevarTutorium.IdPago
                        select new FormaPagoMV
                        {
                            Id = FormaPago.IdPago,
                            TipoPago = FormaPago.TipoPago,
                            ValoraPagar = FormaPago.ValoraPagar,
                            Barrio = ResevarTutorium.Barrio,
                            DescripcionTutoria = ResevarTutorium.DescripcionTutoria,

                        };
            return query.ToList();

            // return await _context.FormaPagos.ToListAsync();
        }

        // GET: api/FormaPagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPago>> GetFormaPago(int id)
        {
            if (_context.FormaPagos == null)
            {
                return NotFound();
            }
            var formaPago = await _context.FormaPagos.FindAsync(id);

            if (formaPago == null)
            {
                return NotFound();
            }

            return formaPago;
        }

        // PUT: api/FormaPagoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormaPago(int id, FormaPago formaPago)
        {
            if (id != formaPago.IdPago)
            {
                return BadRequest();
            }

            _context.Entry(formaPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagoExists(id))
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

        // POST: api/FormaPagoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormaPago>> PostFormaPago(FormaPago formaPago)
        {
            if (_context.FormaPagos == null)
            {
                return Problem("Entity set 'T5sContext.FormaPagos'  is null.");
            }
            _context.FormaPagos.Add(formaPago);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FormaPagoExists(formaPago.IdPago))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFormaPago", new { id = formaPago.IdPago }, formaPago);
        }

        // DELETE: api/FormaPagoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormaPago(int id)
        {
            if (_context.FormaPagos == null)
            {
                return NotFound();
            }
            var formaPago = await _context.FormaPagos.FindAsync(id);
            if (formaPago == null)
            {
                return NotFound();
            }

            _context.FormaPagos.Remove(formaPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormaPagoExists(int id)
        {
            return (_context.FormaPagos?.Any(e => e.IdPago == id)).GetValueOrDefault();
        }
    }
}
