using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DwellAPI.Model;

namespace DwellAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutinesController : ControllerBase
    {
        private readonly DwellAPIContext _context;

        public RoutinesController(DwellAPIContext context)
        {
            _context = context;
        }

        // GET: api/Routines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Routines>>> GetRoutines()
        {
            return await _context.Routines.ToListAsync();
        }

        // GET: api/Routines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Routines>> GetRoutines(int id)
        {
            var routines = await _context.Routines.FindAsync(id);

            if (routines == null)
            {
                return NotFound();
            }

            return routines;
        }

        // PUT: api/Routines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutines(int id, Routines routines)
        {
            if (id != routines.Id)
            {
                return BadRequest();
            }

            _context.Entry(routines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutinesExists(id))
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

        // POST: api/Routines
        [HttpPost]
        public async Task<ActionResult<Routines>> PostRoutines(Routines routines)
        {
            _context.Routines.Add(routines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoutines", new { id = routines.Id }, routines);
        }

        // DELETE: api/Routines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Routines>> DeleteRoutines(int id)
        {
            var routines = await _context.Routines.FindAsync(id);
            if (routines == null)
            {
                return NotFound();
            }

            _context.Routines.Remove(routines);
            await _context.SaveChangesAsync();

            return routines;
        }

        private bool RoutinesExists(int id)
        {
            return _context.Routines.Any(e => e.Id == id);
        }
    }
}
