using ACUnicep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Interfaces
{
    public interface IAtividadesComplementaresRepository
    {
        Task<AtividadeComplementar> GetById(Guid id);
        Task<IEnumerable<AtividadeComplementar>> GetByAluno(string cdUsuario);
        Task Adicionar(AtividadeComplementar atividadeComplementar);
        Task Atualizar(AtividadeComplementar atividadeComplementar, Guid id);
        Task Remover(AtividadeComplementar atividadeComplementar);
    }
}
