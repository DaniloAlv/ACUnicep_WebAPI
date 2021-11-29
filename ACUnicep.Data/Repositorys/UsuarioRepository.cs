using ACUnicep.Data.Context;
using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ACUnicep.Data.Repositorys
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly AcUnicepDbContext _dbContext;

        public UsuarioRepository(AcUnicepDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RegistrarUsuario(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Usuario> RetornaUsuario(Guid cdUsuario)
        {
            return await _dbContext.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.CodigoUsuario.Equals(cdUsuario));
        }

        public async Task<Usuario> RetornaUsuarioFiltrado(Expression<Func<Usuario, bool>> predicate)
        {
            return await _dbContext.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }
    }
}
