using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ACUnicep.Domain.ViewModels
{
    public class AtividadeComplementarRequest
    {
        [Required(ErrorMessage = "Informe o tipo de atividade efetuada.")]
        public int TipoAtividadeId { get; set; }

        public string CodigoProfessor { get; set; }
        public int QuantidadeHoras { get; set; }

        [Required(ErrorMessage = "Nenhum arquivo foi adicionado para submeter.")]
        public IFormFile Arquivo { get; set; }

        public string Observacoes { get; set; }
    }
}
