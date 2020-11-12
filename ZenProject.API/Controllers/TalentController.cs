using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenProject.API.Data;
using ZenProject.API.Data.Entities;

namespace ZenProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TalentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Talent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Talent>>> GetTalent()
        {
            return await _context.Talents.ToListAsync();
        }

        // GET: api/Talent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Talent>> GetTalent(int id)
        {
            var talent = await _context.Talents.FindAsync(id);

            if (talent == null)
            {
                return NotFound();
            }

            return talent;
        }

        // POST: api/Talent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Talent>> PostTalent(Talent talent)
        {
            _context.Talents.Add(talent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTalent", new { id = talent.TalentId }, talent);
        }

        // PUT: api/Talent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalent(int id, Talent talent)
        {
            if (id != talent.TalentId)
            {
                return BadRequest();
            }

            _context.Entry(talent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalentExists(id))
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

        // DELETE: api/Talent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Talent>> DeleteTalent(int id)
        {
            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }

            _context.Talents.Remove(talent);
            await _context.SaveChangesAsync();

            return talent;
        }

        private bool TalentExists(int id)
        {
            return _context.Talents.Any(e => e.TalentId == id);
        }
    }
}
