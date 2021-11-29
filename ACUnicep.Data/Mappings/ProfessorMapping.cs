using ACUnicep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACUnicep.Data.Mappings
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(p => p.CodigoRegistro);

            builder.Property(p => p.CodigoRegistro).HasColumnName("COD_PROFESSOR")
                .IsRequired().HasMaxLength(7).IsFixedLength();

            builder.Property(p => p.Nome).HasColumnName("NOME")
                .IsRequired().HasMaxLength(75);

            builder.Property(a => a.UsuarioId).HasColumnName("COD_USUARIO")
                .IsRequired();

            //Relacionamentos
            builder.HasOne(p => p.Usuario).WithOne().HasForeignKey<Professor>(p => p.UsuarioId);
            builder.HasMany(p => p.AtividadesComplementares).WithOne(ac => ac.Professor)
                .HasForeignKey(ac => ac.CodigoProfessor);
        }
    }
}
