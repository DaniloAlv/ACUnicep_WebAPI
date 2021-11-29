using ACUnicep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Interfaces.Repository
{
    public interface IAlunoRepository
    {
        Task<Aluno> RetornaAluno(string RA);
        Task<Aluno> RetornaAlunoFiltrado(Expression<Func<Aluno, bool>> predicate);
    }
}
