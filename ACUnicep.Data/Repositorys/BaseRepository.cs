using ACUnicep.Data.Context;
using ACUnicep.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Data.Repositorys
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AcUnicepDbContext _dbContext;

        public BaseRepository(AcUnicepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
