using ACUnicep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> RetornaUsuario(Guid id);
        Task<Usuario> RetornaUsuarioFiltrado(Expression<Func<Usuario, bool>> predicate);
        Task RegistrarUsuario(Usuario aluno);
    }
}
