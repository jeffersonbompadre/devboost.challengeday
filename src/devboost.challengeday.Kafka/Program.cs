using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using devboost.challengeday.Kafka.Config;
using devboost.challengeday.Kafka.Interfaces;
using devboost.challengeday.Kafka.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    services.AddHttpClient();
                    services.AddHostedService<Worker>();
                    services.AddScoped<IConsumer,Consumer>();
                    services.AddScoped<ITransactionHttpFactory,TransactionHttpFactory>();

                });
    }
}
