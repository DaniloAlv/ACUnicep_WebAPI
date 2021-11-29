using ACUnicep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ACUnicep.Data.Context
{
    public class AcUnicepDbContext : DbContext
    {
        public AcUnicepDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<AtividadeComplementar> AtividadesComplementares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcUnicepDbContext).Assembly);

            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
