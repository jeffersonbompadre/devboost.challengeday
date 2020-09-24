namespace devboost.challengeday.Infra.Repositorios
{
    using System.Threading.Tasks;

    using devboost.challengeday.Domain.Interfaces;
    using devboost.challengeday.Domain.Models;
    using devboost.challengeday.Infra.DataModels;

    using MongoDB.Driver;

    public class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {

        private readonly IMongoCollection<ContaCorrenteDataModel> _ContaCorrenteCollection;
        public async Task Deposito(ContaCorrente contaCorrente)
        {
            throw new System.NotImplementedException();
        }

        public async Task Saque(ContaCorrente contaCorrente)
        {
            throw new System.NotImplementedException();
        }

        public async Task<decimal> Saldo(ContaCorrente contaCorrente)
        {
            throw new System.NotImplementedException();
        }
    }
}