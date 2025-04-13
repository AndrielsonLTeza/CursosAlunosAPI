namespace CursosAlunosAPI.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
