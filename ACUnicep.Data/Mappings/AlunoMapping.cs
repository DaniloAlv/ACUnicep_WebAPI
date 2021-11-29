using ACUnicep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACUnicep.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.RA);

            builder.Property(a => a.RA)
                .IsRequired().HasMaxLength(7).IsFixedLength();

            builder.Property(a => a.Nome).HasColumnName("NOME")
                .IsRequired().HasMaxLength(128);

            builder.Property(a => a.UsuarioId).HasColumnName("COD_USUARIO")
                .IsRequired();

            builder.Property(a => a.CursoId).HasColumnName("COD_CURSO")
                .IsRequired();

            //Relacionamentos
            builder.HasOne(a => a.Usuario).WithOne().HasForeignKey<Aluno>(a => a.UsuarioId);
            builder.HasMany(a => a.AtividadesComplementares).WithOne(ac => ac.Aluno)
                .HasForeignKey(ac => ac.CodigoAluno);
        }
    }
}
