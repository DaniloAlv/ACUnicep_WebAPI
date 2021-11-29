using System;

namespace ACUnicep.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            CodigoUsuario = Guid.NewGuid();
        }

        public Guid CodigoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int NivelAcesso { get; set; }
        public bool Valido { get; set; }
    }
}
