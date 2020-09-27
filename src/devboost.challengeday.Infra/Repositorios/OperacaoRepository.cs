namespace devboost.challengeday.Infra.Repositorios
{
    using devboost.challengeday.Domain.Interfaces;
    using devboost.challengeday.Domain.Models;
    using devboost.challengeday.Infra.Data;
    using devboost.challengeday.Infra.DataModels;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using ServiceStack;
    using ServiceStack.Text;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The Bank transaction repository.
    /// </summary>
    public class OperacaoRepository : IOperacaoRepository
    {

        private readonly BankMongoDbContext _bankMongoDbContext;
               
        private FilterDefinitionBuilder<OperacaoDataModel> _filterDef => Builders<OperacaoDataModel>.Filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperacaoRepository"/> class.
        /// </summary>
        /// <param name="database">
        /// The database.
        /// </param>
        public OperacaoRepository(BankMongoDbContext bankMongoDbContext) {

            _bankMongoDbContext = bankMongoDbContext;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<Operacao>> GetAllAsync()
        {
            var list = await _bankMongoDbContext.Operacao.Find(_ => true).ToListAsync();
            return list;

        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Obsolete]
        public async Task<Operacao> GetByIdAsync(Guid id)
        {
           var p = (await _bankMongoDbContext.Operacao.FindAsync(x => x.Id == id)).FirstOrDefault();
           return p;

        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="operacao">
        /// The conta corrente.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Operacao> AddAsync(Operacao operacao)
        {
            await _bankMongoDbContext.Operacao.InsertOneAsync(operacao);
            return operacao;

        }
    }
}