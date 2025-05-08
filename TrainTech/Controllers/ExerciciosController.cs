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
    public class ExerciciosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExerciciosController(AppDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "Usuario")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Exercicios.ToListAsync();

            return Ok(model);
        }

        [Authorize(Roles ="Administrador, Usuario")]
        [HttpPost]
        public async Task<ActionResult> Create(Exercicio model)
        {
            if (model.Series <= 0 || model.Load <= 0)
            {
                return BadRequest(new { message = "Séries e cargas devem ser informadas" });
            }


            _context.Exercicios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }


        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Exercicios
                 .Include(t => t.Usuarios).ThenInclude(t => t.Usuario)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Exercicio model)
        {
            if (id != model.Id) return BadRequest();

            var modelDb = await _context.Exercicios.AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (modelDb == null) return NotFound();

            _context.Exercicios.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Exercicios.FindAsync(id);

            if (model == null) return NotFound();

            _context.Exercicios.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("{id}/usuarios")]
        public async Task<ActionResult> AddUsuario(int id, ExercicioUsuarios model)
        {
            if (id != model.ExerciciosId) return BadRequest();

            _context.ExerciciosUsuarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.ExerciciosId }, model);
        }

        [HttpDelete("{id}/usuarios/{usuarioId}")]
        public async Task<ActionResult> DeleteUsuario(int id, int usuarioId)
        {
            var model = await _context.ExerciciosUsuarios
                .Where(c => c.ExerciciosId == id && c.UsuarioId == usuarioId )
                .FirstOrDefaultAsync();

            if (model == null) return NotFound();   

            _context.ExerciciosUsuarios.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
           
        }

    }
}
