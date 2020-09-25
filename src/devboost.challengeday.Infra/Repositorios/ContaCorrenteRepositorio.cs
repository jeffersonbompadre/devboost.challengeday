namespace devboost.challengeday.Infra.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using devboost.challengeday.Domain.Interfaces;
    using devboost.challengeday.Domain.Models;
    using devboost.challengeday.Infra.DataModels;

    using MongoDB.Driver;

    public class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {

        private readonly IMongoCollection<ContaCorrenteDataModel> _ContaCorrenteCollection;


        public ContaCorrenteRepositorio(IMongoDatabase database)
        {
            _ContaCorrenteCollection = database.GetCollection<ContaCorrenteDataModel>("Pedido"); ;
        }

        public async Task<List<ContaCorrente>> GetAll(ContaCorrente contaCorrente)
        {
            throw new NotImplementedException();
        }

        public async Task<ContaCorrente> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContaCorrente> Save(ContaCorrente contaCorrente)
        {
            throw new NotImplementedException();
        }
    }
}