using CursosAlunosAPI.Models;
using CursosAlunosAPI.Repositories.Interfaces;

namespace CursosAlunosAPI.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly List<Aluno> _alunos = new List<Aluno>();
        private int _nextId = 1;

        public Task<IEnumerable<Aluno>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Aluno>>(_alunos);
        }

        public Task<Aluno?> GetByIdAsync(int id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(aluno);
        }

        public Task<Aluno> AddAsync(Aluno aluno)
        {
            aluno.Id = _nextId++;
            _alunos.Add(aluno);
            return Task.FromResult(aluno);
        }

        public Task<bool> UpdateAsync(Aluno aluno)
        {
            var index = _alunos.FindIndex(a => a.Id == aluno.Id);
            if (index == -1)
                return Task.FromResult(false);

            _alunos[index] = aluno;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
                return Task.FromResult(false);

            _alunos.Remove(aluno);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Aluno>> GetAlunosByCursoIdAsync(int cursoId)
        {
            var alunos = _alunos.Where(a => a.CursoId == cursoId);
            return Task.FromResult(alunos);
        }
    }
}

