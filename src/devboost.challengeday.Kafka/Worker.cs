using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using devboost.challengeday.Kafka.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace devboost.challengeday.Kafka
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsumer _consumer;

        public Worker(ILogger<Worker> logger, IConsumer consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("Consumindo mensagens com o Kafka");
                           
                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                await _consumer.Publish();
                              
                await Task.Delay(1000, stoppingToken);
            }

            _logger.LogInformation("Finalisando mensagens com o Kafka");
        }
    }
}
