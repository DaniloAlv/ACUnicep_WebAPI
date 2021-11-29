using System.ComponentModel.DataAnnotations;

namespace ACUnicep.WebAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Necessário informar seu usuário!")]
        public string CodigoUsuario { get; set; }

        [Required(ErrorMessage = "Necessário informar a sua senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o seu tipo de usuário")]
        public int TipoUsuario { get; set; }
    }
}
