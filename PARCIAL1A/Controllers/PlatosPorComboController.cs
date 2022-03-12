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
    public class PlatosPorComboController : ControllerBase
    {
        private readonly PARCIAL1AContext _context;

        public PlatosPorComboController(PARCIAL1AContext context)
        {
            _context = context;
        }

        // GET: api/PlatosPorCombo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatosPorCombo>>> GetPlatosPorCombos()
        {
            return await _context.PlatosPorCombos.ToListAsync();
        }

        // GET: api/PlatosPorCombo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatosPorCombo>> GetPlatosPorCombo(int id)
        {
            var platosPorCombo = await _context.PlatosPorCombos.FindAsync(id);

            if (platosPorCombo == null)
            {
                return NotFound();
            }

            return platosPorCombo;
        }

        // PUT: api/PlatosPorCombo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatosPorCombo(int id, PlatosPorCombo platosPorCombo)
        {
            if (id != platosPorCombo.PlatosPorComboId)
            {
                return BadRequest();
            }

            _context.Entry(platosPorCombo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatosPorComboExists(id))
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

        // POST: api/PlatosPorCombo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlatosPorCombo>> PostPlatosPorCombo(PlatosPorCombo platosPorCombo)
        {
            _context.PlatosPorCombos.Add(platosPorCombo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatosPorCombo", new { id = platosPorCombo.PlatosPorComboId }, platosPorCombo);
        }

        // DELETE: api/PlatosPorCombo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatosPorCombo(int id)
        {
            var platosPorCombo = await _context.PlatosPorCombos.FindAsync(id);
            if (platosPorCombo == null)
            {
                return NotFound();
            }

            _context.PlatosPorCombos.Remove(platosPorCombo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlatosPorComboExists(int id)
        {
            return _context.PlatosPorCombos.Any(e => e.PlatosPorComboId == id);
        }
    }
}
