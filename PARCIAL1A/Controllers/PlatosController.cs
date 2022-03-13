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
    public class PlatosController : ControllerBase
    {
        private readonly PARCIAL1AContext _context;

        public PlatosController(PARCIAL1AContext context)
        {
            _context = context;
        }

        // GET: api/Platos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plato>>> GetPlatos()
        {
            var list = (from p in _context.Platos                        
                        select new
                        {
                            p.PlatoId,                           
                            p.NombrePlato,
                            p.DescripcionPlato,
                            p.Precio,
                            p.TiempoPreparacion,
                            p.Imagen,
                            p.AplicaPropina,
                            p.Lunes,
                            p.Martes,
                            p.Miercoles,
                            p.Jueves,
                            p.Viernes,
                            p.Sabado,
                            p.Domingo,
                            p.Estado,
                            p.FechaCreacion,
                            p.FechaModificacion,
                        }).OrderBy(p => p.PlatoId);

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        // GET: api/Platos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plato>> GetPlato(int id)
        {
            //var plato = await _context.Platos.FindAsync(id);

            //if (plato == null)
            //{
            //    return NotFound();
            //}

            //return plato;

            var list = (from p in _context.Platos                     
                        where p.PlatoId == id
                        select new
                        {
                            p.PlatoId,                          
                            p.NombrePlato,
                            p.DescripcionPlato,
                            p.Precio,
                            p.TiempoPreparacion,
                            p.Imagen,
                            p.AplicaPropina,
                            p.Lunes,
                            p.Martes,
                            p.Miercoles,
                            p.Jueves,
                            p.Viernes,
                            p.Sabado,
                            p.Domingo,
                            p.Estado,
                            p.FechaCreacion,
                            p.FechaModificacion,
                        }).FirstOrDefault();

            if (list != null)
            {
                return Ok(list);
            }

            return NotFound();
        }

        // PUT: api/Platos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlato(int id, Plato plato)
        {
            if (id != plato.PlatoId)
            {
                return BadRequest();
            }

            _context.Entry(plato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoExists(id))
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

        // POST: api/Platos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plato>> PostPlato(Plato plato)
        {
            _context.Platos.Add(plato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlato", new { id = plato.PlatoId }, plato);
        }

        // DELETE: api/Platos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlato(int id)
        {
            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }

            _context.Platos.Remove(plato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlatoExists(int id)
        {
            return _context.Platos.Any(e => e.PlatoId == id);
        }
    }
}
