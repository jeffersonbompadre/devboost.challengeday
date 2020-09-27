namespace devboost.challengeday.IoC
{
    using devboost.challengeday.Services.Interfaces;
    using devboost.challengeday.Infra.Repositorios;
    using devboost.challengeday.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using MongoDB.Driver;
    using devboost.challengeday.Domain.Interfaces;
    using devboost.challengeday.Infra.Data;

    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration config)
        {

            services.AddScoped<IOperacaoRepository, OperacaoRepository>();
            services.AddScoped<IOperacaoService, OperacaoService>();
          
            return services;
        }
    }
}