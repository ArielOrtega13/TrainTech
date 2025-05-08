using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainTech.Models;

namespace TrainTech.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiaTreinoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiaTreinoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.DiaTreino.ToListAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DiaTreino model)
        {
           
           _context.DiaTreino.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.DiaTreino
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DiaTreino model)
        {
            if (id != model.Id) return BadRequest();

            var modelDb = await _context.DiaTreino.AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (modelDb == null) return NotFound();

            _context.DiaTreino.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.DiaTreino.FindAsync(id);

            if (model == null) return NotFound();

            _context.DiaTreino.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
