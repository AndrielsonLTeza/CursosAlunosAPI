using CursosAlunosAPI.Models;

namespace CursosAlunosAPI.Services.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso?> GetByIdAsync(int id);
        Task<Curso> AddAsync(Curso curso);
        Task<bool> UpdateAsync(Curso curso);
        Task<bool> DeleteAsync(int id);
    }
}
