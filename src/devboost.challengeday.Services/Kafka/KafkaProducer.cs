using Confluent.Kafka;
using devboost.challengeday.Domain.Commands.Request;
using devboost.challengeday.Services.Kafka.Interfaces;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace devboost.challengeday.Services.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        public async Task Operacao(ContaCorrenteRequest contaCorrenteRequest)
        {
            const string bootstrapServers = "localhost:9092";
            const string nomeTopic = "financial-operation-request";
            string payload = $"Mensagem => {Guid.NewGuid()} Hora => {DateTime.Now}";

            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = bootstrapServers
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync(
                        nomeTopic,
                        new Message<Null, string>
                        { 
                            Value = ConvertPedidoToJson(contaCorrenteRequest)
                        });
                    Console.WriteLine(
                        $"Mensagem: {payload} | " +
                        $"Status: { result.Status.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção: {ex.GetType().FullName} | " + $"Mensagem: {ex.Message}");
            }
        }

        private string ConvertPedidoToJson(ContaCorrenteRequest contaCorrenteRequest) =>
            JsonConvert.SerializeObject(contaCorrenteRequest);
    }
}