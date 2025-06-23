using FuncionariosAPI.Data;
using FuncionariosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuncionariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetAll()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> Get(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return NotFound();
            return funcionario;
        }

        [HttpPost]
        public async Task<ActionResult<Funcionario>> Post(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = funcionario.Id_funcionario }, funcionario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Funcionario funcionario)
        {
            if (id != funcionario.Id_funcionario) return BadRequest();

            _context.Entry(funcionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return NotFound();

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
