using Microsoft.AspNetCore.Mvc;
using CursosAlunosAPI.Models;
using CursosAlunosAPI.Services.Interfaces;
using CursosAlunosAPI.Models.DTOs;

namespace CursosAlunosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        private readonly IAlunoService _alunoService;

        public CursosController(ICursoService cursoService, IAlunoService alunoService)
        {
            _cursoService = cursoService;
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetAll()
        {
            var cursos = await _cursoService.GetAllAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetById(int id)
        {
            var curso = await _cursoService.GetByIdAsync(id);
            
            if (curso == null)
                return NotFound();
                
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> Create(Curso curso)
        {
            try
            {
                var novoCurso = await _cursoService.AddAsync(curso);
                return CreatedAtAction(nameof(GetById), new { id = novoCurso.Id }, novoCurso);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Curso curso)
        {
            if (id != curso.Id)
                return BadRequest("ID do curso na URL não corresponde ao ID no corpo da requisição");

            try
            {
                var success = await _cursoService.UpdateAsync(curso);
                
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
            try
            {
                var success = await _cursoService.DeleteAsync(id);
                
                if (!success)
                    return NotFound();
                    
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/matricular")]
        public async Task<IActionResult> MatricularAluno(int id, MatriculaDTO matricula)
        {
            try
            {
                var success = await _alunoService.MatricularEmCursoAsync(matricula.AlunoId, id);
                
                if (!success)
                    return NotFound();
                    
                return Ok($"Aluno matriculado com sucesso no curso {id}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/alunos")]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunosByCurso(int id)
        {
            // Verifica se o curso existe
            var curso = await _cursoService.GetByIdAsync(id);
            if (curso == null)
                return NotFound("Curso não encontrado");
                
            var alunos = await _alunoService.GetAlunosByCursoIdAsync(id);
            return Ok(alunos);
        }
    }
}
