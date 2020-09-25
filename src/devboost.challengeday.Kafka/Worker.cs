using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace devboost.challengeday.Kafka
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                Console.WriteLine(""); Console.WriteLine("");
                Console.WriteLine("Consumindo mensagens com o Kafka");
                Console.WriteLine("");
                Console.WriteLine("");
                const string bootstrapServers = "localhost:9092";
                const string nomeTopic = "financial-operation-request";
                Console.WriteLine($"BootstrapServers = {bootstrapServers}");
                Console.WriteLine($"Topic = {nomeTopic}");

               

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                    consumer.Subscribe(nomeTopic);

                    try
                    {
                        while (true)
                        {
                            var cr = consumer.Consume(cts.Token);
                            Console.WriteLine(
                                $"Mensagem lida: {cr.Message.Value}");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                        Console.WriteLine("Cancelando a execução do consumidor...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exceção: {ex.GetType().FullName} | " + $"Mensagem: {ex.Message}");
                }
                                              
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
