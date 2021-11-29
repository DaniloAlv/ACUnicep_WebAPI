using ACUnicep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Interfaces.Services
{
    public interface IAtividadesComplementaresService
    {
        Task<AtividadeComplementar> GetById(Guid id);
        Task<IEnumerable<AtividadeComplementar>> GetByAluno(string cdUsuario);
        Task Adicionar(AtividadeComplementar atividadeComplementar);
        Task Atualizar(AtividadeComplementar atividadeComplementar, Guid id);
        Task Remover(AtividadeComplementar atividadeComplementar);
    }
}
