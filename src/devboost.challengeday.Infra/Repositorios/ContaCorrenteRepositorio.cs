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
    /// The conta corrente repositorio.
    /// </summary>
    public class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {
        /// <summary>
        /// The conta corrente collection.
        /// </summary>
        private readonly IMongoCollection<ContaCorrenteDataModel> _ContaCorrenteCollection;

        /// <summary>
        /// The _filter def.
        /// </summary>
        private FilterDefinitionBuilder<ContaCorrenteDataModel> _filterDef => Builders<ContaCorrenteDataModel>.Filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContaCorrenteRepositorio"/> class.
        /// </summary>
        /// <param name="database">
        /// The database.
        /// </param>
        public ContaCorrenteRepositorio()
        {
            //_ContaCorrenteCollection = database.GetCollection<ContaCorrenteDataModel>("Pedido"); ;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<ContaCorrente>> GetAll()
        {
            //var list = await _ContaCorrenteCollection.Find(_ => true).ToListAsync();

            //return list.ConvertTo<List<ContaCorrente>>();
            return null;
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
        public async Task<ContaCorrente> GetById(Guid id)
        {
            //var bsonId = new BsonBinaryData(id);

            //var filter = _filterDef.Eq(_ => _.Id, bsonId);

            //var p = (await _ContaCorrenteCollection.FindAsync(filter)).FirstOrDefault();

            //return p.ConvertTo<ContaCorrente>();
            return null;
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="contaCorrente">
        /// The conta corrente.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ContaCorrente> Save(ContaCorrenteRequest contaCorrente)
        {
            var model = contaCorrente.ConvertTo<ContaCorrenteDataModel>();


            //await _ContaCorrenteCollection.InsertOneAsync(model);
            //return model.ConvertTo<ContaCorrente>();
            return null;
        }
    }
}