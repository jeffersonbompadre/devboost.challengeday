using devboost.challengeday.Domain.Commands.Request;
using devboost.challengeday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.challengeday.Domain.Interfaces
{
    public interface IContaCorrenteHandler
    {
        Task<decimal> Saldo();
        Task DepositarValor(ContaCorrenteRequest contaCorrente);

        Task SacarValor(ContaCorrenteRequest contaCorrente);
    }
}
