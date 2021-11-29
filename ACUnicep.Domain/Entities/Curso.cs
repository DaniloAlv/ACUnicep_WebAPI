using System.ComponentModel;

namespace ACUnicep.Domain.Entities
{
    public enum Curso
    {
        [Description("Administração")]
        Administracao = 1,

        [Description("Arquitetura e Urbanismo")]
        ArquiteturaUrbanismo = 2,

        [Description("Comunicação Social - Publicidade e Propaganda")]
        PublicidadePropaganda = 3,

        [Description("Pedagogia")]
        Pedagogia = 4,

        [Description("Engenharia Civil")]
        EngenhariaCivil = 5,

        [Description("Engenharia de Produção")]
        EngenhariaProducao = 6,

        [Description("Sistemas de Informação")]
        SistemasInformacao = 7,

        [Description("Educação Física - Licenciatura")]
        EducacaoFisicaLicenciatura = 8,

        [Description("Educação Física - Bacharelado")]
        EducacaoFisicaBacharelado = 9,

        [Description("Farmácia")]
        Farmacia = 10,
        
        [Description("Fisioterapia")]
        Fisioterapia = 11,

        [Description("Nutrição")]
        Nutricao = 12,

        [Description("Design de Interiores")]
        DesignInteriores = 13,

        [Description("Gestão Financeira")]
        GestaoFinanceira = 14,

        [Description("Gestão da Produção Industrial")]
        GestaoProducaoIndustrial = 15
    }
}
