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
    public class CompraElementoController : ControllerBase
    {
        private readonly PARCIAL1AContext _context;

        public CompraElementoController(PARCIAL1AContext context)
        {
            _context = context;
        }

        // GET: api/CompraElemento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraElemento>>> GetCompraElementos()
        {
            var listadoCompraElemento = (from ce in _context.CompraElementos 
                                         join em in _context.Empresas.DefaultIfEmpty() on ce.EmpresaId equals em.EmpresaId
                                         join el in _context.Elementos.DefaultIfEmpty() on ce.ElementoId equals el.ElementoId
                                         select new 
                                         { ce.CompraId,
                                         Empresa = em.NombreEmpresa,
                                         ce.FechaCompra,
                                         Elemento = el.ElementoId,
                                         ce.Cantidad,
                                         ce.Estado,
                                         ce.FechaCreacion,
                                         ce.FechaModificacion
                                         }).OrderBy(m => m.FechaCreacion);
            if (listadoCompraElemento.Count() > 0)
            { return Ok(listadoCompraElemento); }return NotFound();


            //return await _context.CompraElementos.ToListAsync();
        }

        // GET: api/CompraElemento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraElemento>> GetCompraElemento(int id)
        {
            var compraElemento = (from ce in _context.CompraElementos
                                  join em in _context.Empresas.DefaultIfEmpty() on ce.EmpresaId equals em.EmpresaId
                                  join el in _context.Elementos.DefaultIfEmpty() on ce.EmpresaId equals el.ElementoId
                                  where id == ce.CompraId
                                  select new
                                  {
                                      ce.CompraId,
                                      Empresa = em.EmpresaId,
                                      ce.FechaCompra,
                                      ce.ElementoId,
                                      ce.Cantidad,
                                      ce.Estado,
                                      ce.FechaCreacion,
                                      ce.FechaModificacion
                                  }).FirstOrDefault();

            if (compraElemento != null)
            {
                return Ok(compraElemento);
            }

            return NotFound();
        }

        // PUT: api/CompraElemento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraElemento(int id, CompraElemento compraElemento)
        {
            if (id != compraElemento.CompraId)
            {
                return BadRequest();
            }

            _context.Entry(compraElemento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraElementoExists(id))
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

        // POST: api/CompraElemento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompraElemento>> PostCompraElemento(CompraElemento compraElemento)
        {
            _context.CompraElementos.Add(compraElemento);
            await _context.SaveChangesAsync();

            return Ok(compraElemento);
        }

        // DELETE: api/CompraElemento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraElemento(int id)
        {
            var compraElemento = await _context.CompraElementos.FindAsync(id);
            if (compraElemento == null)
            {
                return NotFound();
            }

            _context.CompraElementos.Remove(compraElemento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraElementoExists(int id)
        {
            return _context.CompraElementos.Any(e => e.CompraId == id);
        }
    }
}
