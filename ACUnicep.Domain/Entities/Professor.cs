using System;
using System.Collections.Generic;

namespace ACUnicep.Domain.Entities
{
    public class Professor
    {
        public string CodigoRegistro { get; set; }
        public string Nome { get; set; }
        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public IEnumerable<AtividadeComplementar> AtividadesComplementares { get; set; }

    }
}
