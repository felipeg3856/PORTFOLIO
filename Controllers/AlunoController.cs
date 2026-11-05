using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PORTFOLIO.Models;

namespace PORTFOLIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public readonly AlunoController _context;
        public AlunoController(AlunoController context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alunos>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> PostAluno(Alunos aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return Ok(``Aluno adicionado com sucesso´´);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Alunos aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(``Aluno atualizado com sucesso´´);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok(``Aluno removido com sucesso´´);
        }
    }
}
