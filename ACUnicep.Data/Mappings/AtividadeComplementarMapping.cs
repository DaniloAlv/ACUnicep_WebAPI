using ACUnicep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ACUnicep.Data.Mappings
{
    public class AtividadeComplementarMapping : IEntityTypeConfiguration<AtividadeComplementar>
    {
        public void Configure(EntityTypeBuilder<AtividadeComplementar> builder)
        {
            builder.HasKey(ac => ac.Id);

            builder.Property(ac => ac.Id).HasColumnName("COD_ATIVIDADE_COMPLEMENTAR")
                .IsRequired();

            builder.Property(ac => ac.CodigoAluno).HasColumnName("COD_ALUNO")
                .IsRequired().HasMaxLength(7).IsFixedLength();

            builder.Property(ac => ac.CodigoProfessor).HasColumnName("COD_PROFESSOR")
                .IsRequired().HasMaxLength(7).IsFixedLength();

            builder.Property(ac => ac.TipoAtividadeId).HasColumnName("COD_TIPO_ATIVIDADE")
                .IsRequired();

            builder.Property(ac => ac.DataSubmissao).HasColumnName("DT_SUBMISSAO")
                .IsRequired().HasDefaultValue(DateTime.Now);

            builder.Property(ac => ac.DataValidacao).HasColumnName("DT_VALIDACAO")
                .IsRequired(false);

            builder.Property(ac => ac.CaminhoArquivo).HasColumnName("CAMINHO_ARQUIVO")
                .IsRequired();

            builder.Property(ac => ac.QuantidadeHoras).HasColumnName("QTD_HORAS")
                .IsRequired().HasDefaultValue(0);

            builder.Property(ac => ac.Observacoes).HasColumnName("OBSERVACOES")
                .IsRequired(false).HasMaxLength(256);

            builder.Property(ac => ac.Valida).HasColumnName("ST_VALIDA")
                .IsRequired().HasDefaultValue(false);


            //Relacionamentos
            builder.HasOne(ac => ac.Aluno).WithMany(a => a.AtividadesComplementares)
                .HasForeignKey(ac => ac.CodigoAluno);

            builder.HasOne(ac => ac.Professor).WithMany(p => p.AtividadesComplementares)
                .HasForeignKey(ac => ac.CodigoProfessor);
        }
    }
}
