using Confluent.Kafka;
using devboost.challengeday.Kafka.Interfaces;
using devboost.challengeday.Services.Commands.Request;
using devboost.challengeday.Services.Kafka.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace devboost.challengeday.Kafka.Services
{
    public class Consumer : IConsumer
    {
        private readonly ILogger<Consumer> _logger;
        private readonly IOptions<KafkaConfig> _options;
        private readonly ITransactionHttpFactory _transactionHttpFactory;

        public Consumer(ILogger<Consumer> logger, IOptions<KafkaConfig> options, ITransactionHttpFactory transactionHttpFactory)
        {
            _logger = logger;
            _options = options;
            _transactionHttpFactory = transactionHttpFactory;
        }

        public async Task<bool> Publish()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _options.Value.UrlBase,
                GroupId = $"{_options.Value.Topic}-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            CancellationTokenSource cts = new CancellationTokenSource();

            try
            {
                using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                consumer.Subscribe(_options.Value.Topic);

                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume(cts.Token);

                        var @event = JsonConvert.DeserializeObject<OperacaoRequest>(cr.Message.Value);

                        Console.WriteLine(cr.Message.Value);

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
