using Microsoft.AspNetCore.Mvc;
using CursosAlunosAPI.Models;
using CursosAlunosAPI.Services.Interfaces;

namespace CursosAlunosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAll()
        {
            var alunos = await _alunoService.GetAllAsync();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetById(int id)
        {
            var aluno = await _alunoService.GetByIdAsync(id);
            
            if (aluno == null)
                return NotFound();
                
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Create(Aluno aluno)
        {
            try
            {
                var novoAluno = await _alunoService.AddAsync(aluno);
                return CreatedAtAction(nameof(GetById), new { id = novoAluno.Id }, novoAluno);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Aluno aluno)
        {
            if (id != aluno.Id)
                return BadRequest("ID do aluno na URL não corresponde ao ID no corpo da requisição");

            try
            {
                var success = await _alunoService.UpdateAsync(aluno);
                
                if (!success)
                    return NotFound();
                    
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _alunoService.DeleteAsync(id);
            
            if (!success)
                return NotFound();
                
            return NoContent();
        }
    }
}
