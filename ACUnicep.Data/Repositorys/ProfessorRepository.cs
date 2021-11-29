using ACUnicep.Data.Context;
using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Data.Repositorys
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AcUnicepDbContext _dbContext;

        public ProfessorRepository(AcUnicepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Professor> RetornaProfessor(string cdProfessor)
        {
            return await _dbContext.Professores
                .AsNoTracking()
                .Include(prof => prof.Usuario)
                .FirstOrDefaultAsync(prof => prof.CodigoRegistro.Equals(cdProfessor, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Professor> RetornaProfessorFiltrado(Expression<Func<Professor, bool>> predicate)
        {
            return await _dbContext.Professores
                .AsNoTracking()
                .Include(prof => prof.Usuario)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
