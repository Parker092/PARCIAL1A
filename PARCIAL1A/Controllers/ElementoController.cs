using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1A.Models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementoController : ControllerBase
    {
        private readonly PARCIAL1AContext _context;

        public ElementoController(PARCIAL1AContext context)
        {
            _context = context;
        }

        // GET: api/Elemento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elemento>>> GetElementos()
        {
            return await _context.Elementos.ToListAsync();
        }

        // GET: api/Elemento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elemento>> GetElemento(int id)
        {
            var elemento = await _context.Elementos.FindAsync(id);

            if (elemento == null)
            {
                return NotFound();
            }

            return elemento;
        }

        // PUT: api/Elemento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElemento(int id, Elemento elemento)
        {
            if (id != elemento.ElementoId)
            {
                return BadRequest();
            }

            _context.Entry(elemento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementoExists(id))
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

        // POST: api/Elemento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Elemento>> PostElemento(Elemento elemento)
        {
            _context.Elementos.Add(elemento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElemento", new { id = elemento.ElementoId }, elemento);
        }

        // DELETE: api/Elemento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElemento(int id)
        {
            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento == null)
            {
                return NotFound();
            }

            _context.Elementos.Remove(elemento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElementoExists(int id)
        {
            return _context.Elementos.Any(e => e.ElementoId == id);
        }
    }
}
