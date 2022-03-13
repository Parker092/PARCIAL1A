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
    public class ElementosPorPlatoController : ControllerBase
    {
        private readonly PARCIAL1AContext _context;

        public ElementosPorPlatoController(PARCIAL1AContext context)
        {
            _context = context;
        }

        // GET: api/ElementosPorPlato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElementosPorPlato>>> GetElementosPorPlatos()
        {
            var list = (from ep in _context.ElementosPorPlatos
                        join e in _context.Platos on ep.PlatoId equals e.PlatoId
                        select new
                        {
                            ep.ElementoPorPlatoId,
                            Plato = e.NombrePlato,
                            ep.Cantidad,
                            ep.Estado,
                            ep.FechaCreacion,
                            ep.FechaModificacion,
                        }).OrderBy(p => p.ElementoPorPlatoId);

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        // GET: api/ElementosPorPlato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElementosPorPlato>> GetElementosPorPlato(int id)
        {
            var list = (from ep in _context.ElementosPorPlatos
                        join e in _context.Platos on ep.PlatoId equals e.PlatoId
                        where id == ep.ElementoPorPlatoId
                        select new
                        {
                            ep.ElementoPorPlatoId,
                            Plato = e.NombrePlato,
                            ep.Cantidad,
                            ep.Estado,
                            ep.FechaCreacion,
                            ep.FechaModificacion,
                        }).FirstOrDefault();

            if (list!= null)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet("search/{param}")]
        public async Task<ActionResult<ElementosPorPlato>> GetElementosPorPlatoNombre(string param)
        {
            var list = (from ep in _context.ElementosPorPlatos
                        join e in _context.Platos on ep.PlatoId equals e.PlatoId
                        where e.NombrePlato==param
                        select new
                        {
                            ep.ElementoPorPlatoId,
                            Plato = e.NombrePlato,
                            ep.Cantidad,
                            ep.Estado,
                            ep.FechaCreacion,
                            ep.FechaModificacion,
                        }).FirstOrDefault();

            if (list != null)
            {
                return Ok(list);
            }

            return NotFound();
        }

        // PUT: api/ElementosPorPlato/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElementosPorPlato(int id, ElementosPorPlato elementosPorPlato)
        {
            if (id != elementosPorPlato.ElementoPorPlatoId)
            {
                return BadRequest();
            }

            _context.Entry(elementosPorPlato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementosPorPlatoExists(id))
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

        // POST: api/ElementosPorPlato
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ElementosPorPlato>> PostElementosPorPlato(ElementosPorPlato elementosPorPlato)
        {
            _context.ElementosPorPlatos.Add(elementosPorPlato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElementosPorPlato", new { id = elementosPorPlato.ElementoPorPlatoId }, elementosPorPlato);
        }

        // DELETE: api/ElementosPorPlato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementosPorPlato(int id)
        {
            var elementosPorPlato = await _context.ElementosPorPlatos.FindAsync(id);
            if (elementosPorPlato == null)
            {
                return NotFound();
            }

            _context.ElementosPorPlatos.Remove(elementosPorPlato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElementosPorPlatoExists(int id)
        {
            return _context.ElementosPorPlatos.Any(e => e.ElementoPorPlatoId == id);
        }
    }
}
