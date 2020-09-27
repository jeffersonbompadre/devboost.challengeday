using devboost.challengeday.Domain.Models;
using devboost.challengeday.Infra.DataModels;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.challengeday.Infra.Data
{
    public class BankMongoDbContext
    {

        private readonly IMongoDatabase _database;

        public BankMongoDbContext(IOptions<MongoDbConfig> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            _database = client.GetDatabase(config.Value.Database);
        }

       public IMongoCollection<Operacao> Operacao => _database.GetCollection<Operacao>("Operacao");
    }
}
