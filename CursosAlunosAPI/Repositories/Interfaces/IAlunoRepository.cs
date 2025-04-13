using CursosAlunosAPI.Models;

namespace CursosAlunosAPI.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task<Aluno?> GetByIdAsync(int id);
        Task<Aluno> AddAsync(Aluno aluno);
        Task<bool> UpdateAsync(Aluno aluno);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Aluno>> GetAlunosByCursoIdAsync(int cursoId);
    }
}