using CursosAlunosAPI.Models;
using CursosAlunosAPI.Repositories.Interfaces;
using CursosAlunosAPI.Services.Interfaces;

namespace CursosAlunosAPI.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ICursoRepository _cursoRepository;

        public AlunoService(IAlunoRepository alunoRepository, ICursoRepository cursoRepository)
        {
            _alunoRepository = alunoRepository;
            _cursoRepository = cursoRepository;
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            return await _alunoRepository.GetAllAsync();
        }

        public async Task<Aluno?> GetByIdAsync(int id)
        {
            return await _alunoRepository.GetByIdAsync(id);
        }

        public async Task<Aluno> AddAsync(Aluno aluno)
        {
            // Validações básicas
            ValidarAluno(aluno);
                
            // Verifica se o curso existe
            var curso = await _cursoRepository.GetByIdAsync(aluno.CursoId);
            if (curso == null)
                throw new ArgumentException("O curso informado não existe");
                
            return await _alunoRepository.AddAsync(aluno);
        }

        public async Task<bool> UpdateAsync(Aluno aluno)
        {
            // Validações básicas
            ValidarAluno(aluno);
                
            // Verifica se o curso existe
            var curso = await _cursoRepository.GetByIdAsync(aluno.CursoId);
            if (curso == null)
                throw new ArgumentException("O curso informado não existe");
                
            return await _alunoRepository.UpdateAsync(aluno);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _alunoRepository.DeleteAsync(id);
        }

        public async Task<bool> MatricularEmCursoAsync(int alunoId, int cursoId)
        {
            var aluno = await _alunoRepository.GetByIdAsync(alunoId);
            if (aluno == null)
                throw new ArgumentException("Aluno não encontrado");

            var curso = await _cursoRepository.GetByIdAsync(cursoId);
            if (curso == null)
                throw new ArgumentException("Curso não encontrado");

            aluno.CursoId = cursoId;
            return await _alunoRepository.UpdateAsync(aluno);
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByCursoIdAsync(int cursoId)
        {
            return await _alunoRepository.GetAlunosByCursoIdAsync(cursoId);
        }

        private void ValidarAluno(Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno.Nome))
                throw new ArgumentException("O nome do aluno é obrigatório");
                
            if (string.IsNullOrEmpty(aluno.Email))
                throw new ArgumentException("O email do aluno é obrigatório");
        }
    }
}
