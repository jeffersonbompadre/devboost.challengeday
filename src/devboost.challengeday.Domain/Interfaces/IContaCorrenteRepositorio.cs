using devboost.challengeday.Domain.Models;
using System.Threading.Tasks;

namespace devboost.challengeday.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IContaCorrenteRepositorio
    {
        Task<List<ContaCorrente>> GetAll();
        Task<ContaCorrente> GetById(Guid id);
        Task<ContaCorrente> Save(ContaCorrente contaCorrente);
    }
}
