using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACUnicep.WebAPI.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Código do usuário é obrigatório!")]
        [MaxLength(7)]
        public string CodigoUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O e-mail informado não está no formato correto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "A senha deve conter entre {0} e {2} caracteres.", MinimumLength = 8)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "É necessário confirmar a senha!")]
        [Compare("Senha", ErrorMessage = "As senhas não condizem entre si!")]
        public string ConfirmaSenha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int TipoUsuario { get; set; }
        public int CursoId { get; set; }
    }
}
