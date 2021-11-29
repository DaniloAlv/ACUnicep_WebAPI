using ACUnicep.Domain.Entities;
using ACUnicep.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> RetornaUsuario(Guid id);
        Task RegistrarUsuario(Usuario usuario);
        Task<Usuario> RetornaUsuarioFiltrado(LoginModel login);
    }
}
