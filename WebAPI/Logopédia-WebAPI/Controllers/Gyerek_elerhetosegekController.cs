using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Logopédia_WebAPI.Models;

namespace Logopédia_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsImplementationPolicy")]
    public class Gyerek_elerhetosegekController : ControllerBase
    {
        private readonly LogopediaContext _context;

        public Gyerek_elerhetosegekController(LogopediaContext context)
        {
            _context = context;
        }

        // GET: api/Gyerek_elerhetosegek
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<Gyerek_elerhetosegek>>> GetGyerek_elerhetosegek()
        {
            return await _context.Gyerek_elerhetosegek.ToListAsync();
        }

        // GET: api/Gyerek_elerhetosegek/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<Gyerek_elerhetosegek>> GetGyerek_elerhetosegek(int id)
        {
            var gyerek_elerhetosegek = await _context.Gyerek_elerhetosegek.FindAsync(id);

            if (gyerek_elerhetosegek == null)
            {
                return NotFound();
            }

            return gyerek_elerhetosegek;
        }

        // PUT: api/Gyerek_elerhetosegek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGyerek_elerhetosegek(int id, Gyerek_elerhetosegek gyerek_elerhetosegek)
        {
            if (id != gyerek_elerhetosegek.elerhetosegID)
            {
                return BadRequest();
            }

            _context.Entry(gyerek_elerhetosegek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Gyerek_elerhetosegekExists(id))
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

        // POST: api/Gyerek_elerhetosegek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("CorsPolicy")]
        [HttpPost]
        public async Task<ActionResult<Gyerek_elerhetosegek>> PostGyerek_elerhetosegek(Gyerek_elerhetosegek gyerek_elerhetosegek)
        {
            _context.Gyerek_elerhetosegek.Add(gyerek_elerhetosegek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGyerek_elerhetosegek", new { id = gyerek_elerhetosegek.elerhetosegID }, gyerek_elerhetosegek);
        }

        // DELETE: api/Gyerek_elerhetosegek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGyerek_elerhetosegek(int id)
        {
            var gyerek_elerhetosegek = await _context.Gyerek_elerhetosegek.FindAsync(id);
            if (gyerek_elerhetosegek == null)
            {
                return NotFound();
            }

            _context.Gyerek_elerhetosegek.Remove(gyerek_elerhetosegek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Gyerek_elerhetosegekExists(int id)
        {
            return _context.Gyerek_elerhetosegek.Any(e => e.elerhetosegID == id);
        }
    }
}
