using ACUnicep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACUnicep.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.CodigoUsuario);

            builder.Property(u => u.CodigoUsuario).HasColumnName("COD_USUARIO")
                .IsRequired();

            builder.Property(u => u.Email).HasColumnName("EMAIL")
                .IsRequired().HasMaxLength(75);

            builder.Property(u => u.Senha).HasColumnName("SENHA")
                .IsRequired();

            builder.Property(u => u.Valido).HasColumnName("ST_VALIDO")
                .IsRequired().HasDefaultValue(false);

            builder.Property(u => u.NivelAcesso).HasColumnName("COD_NIVEL_ACESSO")
                .IsRequired();
        }
    }
}
