using devboost.challengeday.Domain.Commands.Request;
using devboost.challengeday.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<decimal> Saldo()
        {
            var contaCorrentes = await _contaCorrenteRepositorio.GetAll();
            var valor = contaCorrentes.Select(x => x.Valor).FirstOrDefault();

            return valor;
        }

        public async Task DepositarValor(ContaCorrenteRequest contaCorrente)
        {
            var result = await _contaCorrenteRepositorio.Save(contaCorrente);
        }

        public Task SacarValor(ContaCorrenteRequest contaCorrente)
        {
            throw new NotImplementedException();
        }
    }
}
