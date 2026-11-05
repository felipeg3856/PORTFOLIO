using Microsoft.EntityFrameworkCore;

namespace PORTFOLIO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }   
        public DbSet<Models.Alunos> Alunos { get; set; }
        public DbSet<Models.Turmas> Turmas { get; set; }
        public DbSet<Models.Projetos> Projetos { get; set; }
    }
}
