using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Services
{
    public class AtividadesComplementaresService : IAtividadesComplementaresService
    {
        public Task Adicionar(AtividadeComplementar atividadeComplementar)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(AtividadeComplementar atividadeComplementar, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AtividadeComplementar>> GetByAluno(string cdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<AtividadeComplementar> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remover(AtividadeComplementar atividadeComplementar)
        {
            throw new NotImplementedException();
        }
    }
}
