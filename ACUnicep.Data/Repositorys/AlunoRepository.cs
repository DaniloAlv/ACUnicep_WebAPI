using ACUnicep.Data.Context;
using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACUnicep.Data.Repositorys
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AcUnicepDbContext _dbContext;

        public AlunoRepository(AcUnicepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Aluno> RetornaAluno(string RA)
        {
            return await _dbContext.Alunos
                .AsNoTracking()
                .Include(aluno => aluno.Usuario)
                .FirstOrDefaultAsync(aluno => aluno.RA.Equals(RA, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Aluno> RetornaAlunoFiltrado(Expression<Func<Aluno, bool>> predicate)
        {
            return await _dbContext.Alunos
                .AsNoTracking()
                .Include(aluno => aluno.Usuario)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
