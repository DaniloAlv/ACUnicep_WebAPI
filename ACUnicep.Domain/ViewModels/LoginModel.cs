using System;
using System.Collections.Generic;
using System.Text;

namespace ACUnicep.Domain.ViewModels
{
    public class LoginModel
    {
        public string CodigoUsuario { get; set; }
        public string Senha { get; set; }
        public int NivelAcesso { get; set; }
    }
}
