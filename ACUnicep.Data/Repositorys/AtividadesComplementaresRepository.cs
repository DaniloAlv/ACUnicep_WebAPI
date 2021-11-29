using ACUnicep.Data.Context;
using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Data.Repositorys
{
    public class AtividadesComplementaresRepository : BaseRepository, IAtividadesComplementaresRepository
    {
        private readonly AcUnicepDbContext _dbContext;

        public AtividadesComplementaresRepository(AcUnicepDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(AtividadeComplementar atividadeComplementar)
        {
            await _dbContext.AtividadesComplementares
                .AddAsync(atividadeComplementar);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(AtividadeComplementar atividadeComplementar, Guid id)
        {
            _dbContext.AtividadesComplementares
                .Update(atividadeComplementar);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AtividadeComplementar>> GetByAluno(string cdAluno)
        {
            return await _dbContext.AtividadesComplementares
                .AsNoTracking()
                .Where(ac => ac.CodigoAluno.Equals(cdAluno))
                .ToListAsync();
        }

        public async Task<AtividadeComplementar> GetById(Guid id)
        {
            return await _dbContext.AtividadesComplementares
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id.Equals(id));
        }

        public async Task Remover(AtividadeComplementar atividadeComplementar)
        {
            _dbContext.AtividadesComplementares
                .Remove(atividadeComplementar);

            await _dbContext.SaveChangesAsync();
        }
    }
}
