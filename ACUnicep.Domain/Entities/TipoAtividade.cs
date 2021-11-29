using System.ComponentModel;

namespace ACUnicep.Domain.Entities
{
    public enum TipoAtividade
    {
        [Description("Curso de Extensão")]
        CursoExtensao = 1,

        [Description("Congresso")]
        Congresso = 2,

        [Description("Seminário")]
        Seminario = 3,

        [Description("Palestra")]
        Palestra = 4,

        [Description("Workshop")]
        Workshop = 5,

        [Description("Iniciação Científica")]
        IniciacaoCientifica = 6,

        [Description("Estágio")]
        Estagio = 7,

        [Description("Monitoria")]
        Monitoria = 8,

    }
}
