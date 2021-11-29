using ACUnicep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Interfaces.Repository
{
    public interface IProfessorRepository
    {
        Task<Professor> RetornaProfessor(string cdProfessor);
        Task<Professor> RetornaProfessorFiltrado(Expression<Func<Professor, bool>> predicate);
    }
}
