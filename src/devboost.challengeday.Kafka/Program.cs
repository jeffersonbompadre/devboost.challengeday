using devboost.challengeday.Kafka.Interfaces;
using devboost.challengeday.Kafka.Services;
using devboost.challengeday.Services.Kafka.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace devboost.challengeday.Kafka
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {                
                    services.Configure<KafkaConfig>(hostContext.Configuration.GetSection("Kafka"));
                    services.AddHttpClient("contacorrente", opts =>
                    {
                        opts.BaseAddress = new Uri(hostContext.Configuration["ClinteHttp:UrlBase"]);
                    });
                    services.AddHttpClient();
                    services.AddHostedService<Worker>();
                    services.AddTransient<IConsumer,Consumer>();
                    services.AddTransient<ITransactionHttpFactory,TransactionHttpFactory>();

                });
    }
}
