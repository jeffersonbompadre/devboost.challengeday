using Confluent.Kafka;
using devboost.challengeday.Domain.Commands.Request;
using devboost.challengeday.Kafka.Config;
using devboost.challengeday.Kafka.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace devboost.challengeday.Kafka.Services
{
    public class Consumer : IConsumer
    {

        private readonly ILogger<Consumer> _logger;
        private readonly KafkaConfig _kafkaConfig;
        private readonly ITransactionHttpFactory _transactionHttpFactory;

        public Consumer(ILogger<Consumer> logger, KafkaConfig kafkaConfig, ITransactionHttpFactory transactionHttpFactory)
        {
            _logger = logger;
            _kafkaConfig = kafkaConfig;
            _transactionHttpFactory = transactionHttpFactory;
        }

        public async Task<bool> Publish()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaConfig.UrlBase,
                GroupId = $"{_kafkaConfig.Topic}-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            CancellationTokenSource cts = new CancellationTokenSource();

            try
            {
                using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                consumer.Subscribe(_kafkaConfig.Topic);

                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume(cts.Token);

                        var @event = JsonConvert.DeserializeObject<OperacaoRequest>(cr.Message.Value);

                       await  _transactionHttpFactory.Trasaction(@event);
                        
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exceção: {ex.GetType().FullName} | " + $"Mensagem: {ex.Message}");

                return false;
               
            }

            return true;
        }
    }
}
