namespace devboost.challengeday.Infra.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using devboost.challengeday.Domain.Commands.Request;
    using devboost.challengeday.Domain.Interfaces;
    using devboost.challengeday.Domain.Models;
    using devboost.challengeday.Infra.DataModels;

    using MongoDB.Bson;
    using MongoDB.Driver;

    using ServiceStack;

    /// <summary>
    /// The Bank transaction repository.
    /// </summary>
    public class OperacaoRepository : IOperacaoRepository
    {
        /// <summary>
        /// The conta corrente collection.
        /// </summary>
        private readonly IMongoCollection<OperacaoDataModel> _ContaCorrenteCollection;

        /// <summary>
        /// The _filter def.
        /// </summary>
        private FilterDefinitionBuilder<OperacaoDataModel> _filterDef => Builders<OperacaoDataModel>.Filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperacaoRepository"/> class.
        /// </summary>
        /// <param name="database">
        /// The database.
        /// </param>
        public OperacaoRepository(IMongoDatabase database)
        {
            _ContaCorrenteCollection = database.GetCollection<OperacaoDataModel>("Operacao"); ;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<Operacao>> GetAll()
        {
            var list = await _ContaCorrenteCollection.Find(_ => true).ToListAsync();

            return list.ConvertTo<List<Operacao>>();

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
        public async Task<Operacao> GetById(Guid id)
        {
            var bsonId = new BsonBinaryData(id);

            var filter = _filterDef.Eq(_ => _.Id, bsonId);

            var p = (await _ContaCorrenteCollection.FindAsync(filter)).FirstOrDefault();

            return p.ConvertTo<Operacao>();

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
        public async Task<Operacao> Save(Operacao operacao)
        {
            var model = operacao.ConvertTo<OperacaoDataModel>();


            await _ContaCorrenteCollection.InsertOneAsync(model);
            return model.ConvertTo<Operacao>();

        }
    }
}