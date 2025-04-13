using CursosAlunosAPI.Models;
using CursosAlunosAPI.Repositories.Interfaces;
using CursosAlunosAPI.Services.Interfaces;

namespace CursosAlunosAPI.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IAlunoRepository _alunoRepository;

        public CursoService(ICursoRepository cursoRepository, IAlunoRepository alunoRepository)
        {
            _cursoRepository = cursoRepository;
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            var cursos = await _cursoRepository.GetAllAsync();
            
            // Carrega os alunos para cada curso
            foreach (var curso in cursos)
            {
                var alunos = await _alunoRepository.GetAlunosByCursoIdAsync(curso.Id);
                curso.Alunos = alunos.ToList();
            }
            
            return cursos;
        }

        public async Task<Curso?> GetByIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso != null)
            {
                var alunos = await _alunoRepository.GetAlunosByCursoIdAsync(id);
                curso.Alunos = alunos.ToList();
            }
            
            return curso;
        }

        public async Task<Curso> AddAsync(Curso curso)
        {
            if (string.IsNullOrEmpty(curso.Nome))
                throw new ArgumentException("O nome do curso é obrigatório");
                
            await _cursoRepository.AddAsync(curso);
            return curso;
        }

        public async Task<bool> UpdateAsync(Curso curso)
        {
            if (string.IsNullOrEmpty(curso.Nome))
                throw new ArgumentException("O nome do curso é obrigatório");
                
            return await _cursoRepository.UpdateAsync(curso);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Verifica se há alunos matriculados
            var alunosMatriculados = await _alunoRepository.GetAlunosByCursoIdAsync(id);
            if (alunosMatriculados.Any())
                throw new InvalidOperationException("Não é possível excluir um curso com alunos matriculados");
                
            return await _cursoRepository.DeleteAsync(id);
        }
    }
}
