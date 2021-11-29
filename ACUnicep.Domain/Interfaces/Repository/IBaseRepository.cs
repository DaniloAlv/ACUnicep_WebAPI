using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Interfaces
{
    public interface IBaseRepository
    {
        Task<bool> SaveChangesAsync();
    }
}
