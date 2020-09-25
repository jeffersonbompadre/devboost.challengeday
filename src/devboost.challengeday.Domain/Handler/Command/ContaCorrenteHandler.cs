using devboost.challengeday.Domain.Commands.Request;
using devboost.challengeday.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.challengeday.Domain.Handler.Command
{
    public class ContaCorrenteHandler : IContaCorrenteHandler
    {
        readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public ContaCorrenteHandler(IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        public Task<decimal> Saldo()
        {
            throw new NotImplementedException();
        }

        public Task DepositarValor(ContaCorrenteRequest contaCorrente)
        {
            throw new NotImplementedException();
        }

        public Task SacarValor(ContaCorrenteRequest contaCorrente)
        {
            throw new NotImplementedException();
        }
    }
}
