using CursosAlunosAPI.Models;

namespace CursosAlunosAPI.Repositories.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso?> GetByIdAsync(int id);
        Task<Curso> AddAsync(Curso curso);
        Task<bool> UpdateAsync(Curso curso);
        Task<bool> DeleteAsync(int id);
    }
}