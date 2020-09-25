﻿namespace devboost.challengeday.IoC
{
    using devboost.challengeday.Domain.Handler.Command;
    using devboost.challengeday.Domain.Interfaces;
    using devboost.challengeday.Infra.Repositorios;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using MongoDB.Driver;

    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration config)
        {


            services.AddScoped<IContaCorrenteHandler, ContaCorrenteHandler>();
            services.AddScoped<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            //services.AddScoped<IContaCorrenteServico, ContaCorrenteServico>();
            services.AddTransient((mongo) =>
            {
                var database = config.GetValue<string>("MONGO_DATABASE");
                var host = config.GetValue<string>("MONGO_HOST");
                var port = config.GetValue<string>("MONGO_PORT");
                var connectionString = $"mongodb://{host}:{port}";

                var mongoClient = new MongoClient(connectionString);

                return mongoClient.GetDatabase(database);
            });



            return services;
        }
    }
}