using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Base.Server.Data;
using Base.Shared.Modelos;

namespace Base.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionesController : ControllerBase
    {
        private readonly BasedeDatosContext _context;

        public CondicionesController(BasedeDatosContext context)
        {
            _context = context;
        }

        // GET: api/Condicions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condicion>>> GetCondiciones()
        {
          if (_context.Condiciones == null)
          {
              return NotFound();
          }
            return await _context.Condiciones.ToListAsync();
        }

        // GET: api/Condicions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condicion>> GetCondicion(int id)
        {
          if (_context.Condiciones == null)
          {
              return NotFound();
          }
            var condicion = await _context.Condiciones.FindAsync(id);

            if (condicion == null)
            {
                return NotFound();
            }

            return condicion;
        }

        // PUT: api/Condicions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondicion(int id, Condicion condicion)
        {
            if (id != condicion.Id)
            {
                return BadRequest();
            }

            _context.Entry(condicion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondicionExists(id))
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

        // POST: api/Condicions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Condicion>> PostCondicion(Condicion condicion)
        {
          if (_context.Condiciones == null)
          {
              return Problem("Entity set 'BasedeDatosContext.Condiciones'  is null.");
          }
            _context.Condiciones.Add(condicion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondicion", new { id = condicion.Id }, condicion);
        }

        // DELETE: api/Condicions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondicion(int id)
        {
            if (_context.Condiciones == null)
            {
                return NotFound();
            }
            var condicion = await _context.Condiciones.FindAsync(id);
            if (condicion == null)
            {
                return NotFound();
            }

            _context.Condiciones.Remove(condicion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CondicionExists(int id)
        {
            return (_context.Condiciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
