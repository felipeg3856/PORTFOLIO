using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PORTFOLIO.Models;

namespace PORTFOLIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        public readonly TurmaController _context;
        public TurmaController(TurmaController context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turmas>>> GetTurmas()
        {
            return await _context.Turmas.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> PostTurma(Turmas turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
            return Ok(``Turma adicionada com sucesso´´);
        }
    }
}
