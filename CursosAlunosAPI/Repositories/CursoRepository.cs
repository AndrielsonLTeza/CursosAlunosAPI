using CursosAlunosAPI.Models;
using CursosAlunosAPI.Repositories.Interfaces;

namespace CursosAlunosAPI.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly List<Curso> _cursos = new List<Curso>();
        private int _nextId = 1;

        public Task<IEnumerable<Curso>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Curso>>(_cursos);
        }

        public Task<Curso?> GetByIdAsync(int id)
        {
            var curso = _cursos.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(curso);
        }

        public Task<Curso> AddAsync(Curso curso)
        {
            curso.Id = _nextId++;
            _cursos.Add(curso);
            return Task.FromResult(curso);
        }

        public Task<bool> UpdateAsync(Curso curso)
        {
            var index = _cursos.FindIndex(c => c.Id == curso.Id);
            if (index == -1)
                return Task.FromResult(false);

            _cursos[index] = curso;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var curso = _cursos.FirstOrDefault(c => c.Id == id);
            if (curso == null)
                return Task.FromResult(false);

            _cursos.Remove(curso);
            return Task.FromResult(true);
        }
    }
}
