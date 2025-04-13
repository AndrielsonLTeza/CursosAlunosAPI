using CursosAlunosAPI.Models;

namespace CursosAlunosAPI.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task<Aluno?> GetByIdAsync(int id);
        Task<Aluno> AddAsync(Aluno aluno);
        Task<bool> UpdateAsync(Aluno aluno);
        Task<bool> DeleteAsync(int id);
        Task<bool> MatricularEmCursoAsync(int alunoId, int cursoId);
        Task<IEnumerable<Aluno>> GetAlunosByCursoIdAsync(int cursoId);
    }
}