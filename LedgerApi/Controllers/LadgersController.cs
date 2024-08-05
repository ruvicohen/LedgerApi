using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LedgerApi.Data;
using LedgerApi.Models;

namespace LedgerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LadgersController : ControllerBase
    {
        private readonly LedgerApiContext _context;

        public LadgersController(LedgerApiContext context)
        {
            _context = context;
        }

        // GET: api/Ladgers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ladger>>> GetLadger()
        {
            return await _context.Ladger.ToListAsync();
        }

        // GET: api/Ladgers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ladger>> GetLadger(int id)
        {
            var ladger = await _context.Ladger.FindAsync(id);

            if (ladger == null)
            {
                return NotFound();
            }

            return ladger;
        }

        // PUT: api/Ladgers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLadger(int id, Ladger ladger)
        {
            if (id != ladger.Id)
            {
                return BadRequest();
            }

            _context.Entry(ladger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LadgerExists(id))
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

        [HttpPut("PutUserInLedger/{Ledgerid}")]
        public async Task<IActionResult> PutLadger1(int Ledgerid, int userId)
        {
            User user = await _context.User.FindAsync(userId);
            Ladger ladger = await _context.Ladger.FindAsync(Ledgerid);
            if (user == null || ladger == null)
            {
                return BadRequest();
            }
            ladger.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LadgerExists(Ledgerid))
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

        // POST: api/Ladgers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ladger>> PostLadger(Ladger ladger)
        {
            _context.Ladger.Add(ladger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLadger", new { id = ladger.Id }, ladger);
        }

        // DELETE: api/Ladgers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLadger(int id)
        {
            var ladger = await _context.Ladger.FindAsync(id);
            if (ladger == null)
            {
                return NotFound();
            }

            _context.Ladger.Remove(ladger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LadgerExists(int id)
        {
            return _context.Ladger.Any(e => e.Id == id);
        }
    }
}
