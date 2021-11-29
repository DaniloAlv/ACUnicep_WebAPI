using System;
using System.Collections.Generic;

namespace ACUnicep.Domain.Entities
{
    public class Aluno
    {
        public string RA { get; set; }
        public string Nome { get; set; }
        public Guid UsuarioId { get; set; }
        public int CursoId { get; set; }

        public Usuario Usuario { get; set; }
        public IEnumerable<AtividadeComplementar> AtividadesComplementares { get; set; }
    }
}
