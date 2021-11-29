using System;

namespace ACUnicep.Domain.Entities
{
    public class AtividadeComplementar
    {
        public AtividadeComplementar()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int TipoAtividadeId { get; set; }
        public string CodigoAluno { get; set; }
        public string CodigoProfessor { get; set; }
        public int QuantidadeHoras { get; set; }
        public string CaminhoArquivo { get; set; }
        public DateTime DataSubmissao { get; set; }
        public DateTime? DataValidacao { get; set; }
        public bool Valida { get; set; }
        public string Observacoes { get; set; }

        public Aluno Aluno { get; set; }
        public Professor Professor { get; set; }
    }
}
