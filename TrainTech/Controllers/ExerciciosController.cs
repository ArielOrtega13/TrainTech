using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainTech.Models;

namespace TrainTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciciosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExerciciosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Exercicios.ToListAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Exercicio model)
        {
            if (model.Series <= 0 || model.Load <= 0)
            {
                return BadRequest(new { message = "Séries e cargas devem ser informadas" });
            }


            _context.Exercicios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
           var model = await _context.Exercicios
                .FirstOrDefaultAsync(c => c.Id == id);

            if(model == null) return NotFound();   

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Exercicio model)
        {
           if(id != model.Id) return BadRequest();

            var modelDb = await _context.Exercicios.AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == id);

           if(modelDb == null) return NotFound();   

           _context.Exercicios.Update(model);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
          var model = await _context.Exercicios.FindAsync(id);

            if(model == null) return NotFound();

            _context.Exercicios.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
