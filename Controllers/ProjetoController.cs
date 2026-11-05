using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PORTFOLIO.Models;

namespace PORTFOLIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        public readonly ProjetoController _context;
        public ProjetoController(ProjetoController context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projetos>>> GetProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> PostProjeto(Projetos projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
            return Ok(``Projeto adicionado com sucesso´´);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjeto(int id, Projetos projeto)
        {
            if (id != projeto.Id)
            {
                return BadRequest();
            }

            _context.Entry(projeto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(``Projeto atualizado com sucesso´´);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return Ok(``Projeto removido com sucesso´´);
        }
    }
}
