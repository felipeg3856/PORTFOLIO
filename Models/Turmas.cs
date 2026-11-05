namespace PORTFOLIO.Models
{
    public class Turmas
    {
        public int Id { get; set; }
        public string NomeTurma { get; set; }
        public string Professor { get; set; }
        public Alunos? AlunoId { get; set; }
    }
}
