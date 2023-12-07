﻿using System;
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
    public class CarrosController : ControllerBase
    {
        private readonly BasedeDatosContext _context;

        public CarrosController(BasedeDatosContext context)
        {
            _context = context;
        }

        // GET: api/Carroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarros()
        {
          if (_context.Carros == null)
          {
              return NotFound();
          }
            return await _context.Carros.ToListAsync();
        }

        // GET: api/Carroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarro(int id)
        {
          if (_context.Carros == null)
          {
              return NotFound();
          }
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        // PUT: api/Carroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(int id, Carro carro)
        {
            if (id != carro.Id)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
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

        // POST: api/Carroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
          if (_context.Carros == null)
          {
              return Problem("Entity set 'BasedeDatosContext.Carros'  is null.");
          }
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarro", new { id = carro.Id }, carro);
        }

        // DELETE: api/Carroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            if (_context.Carros == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(int id)
        {
            return (_context.Carros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
