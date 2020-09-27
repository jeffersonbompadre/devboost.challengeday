using Confluent.Kafka;
using devboost.challengeday.Services.Kafka.Config;
using devboost.challengeday.Services.Kafka.Interfaces;
using devboost.challengeday.Shared.Event;
using devboost.challengeday.Shared.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.challengeday.Services.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IOptions<KafkaConfig> _options;
        private readonly ResponseResult _response;

        public KafkaProducer(IOptions<KafkaConfig> options)
        {
            _options= options;
            _response = new ResponseResult();
        }

        public async Task<ResponseResult> OperacaoAsync (CriadoOperacaoEvento criadoOperacaoEventos)
        {

            criadoOperacaoEventos.Validate();

            if (criadoOperacaoEventos.Notifications.Any())
            {
                _response.AddNotifications(criadoOperacaoEventos.Notifications);
                return _response;
            }
       
            string payload = $"=> {criadoOperacaoEventos.IdTransacao} Hora => {DateTime.Now}";

            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = _options.Value.UrlBase
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync(
                        _options.Value.Topic,
                        new Message<Null, string>
                        { 
                            Value = ConvertPedidoToJson(criadoOperacaoEventos)
                        });
                 
                    _response.AddValue($"Mensagem: {payload} | " +
                        $"Status: { result.Status.ToString()}");
                }
            }
            catch (Exception ex)
            {
                _response.AddNotification(new Flunt.Notifications.Notification("OperacaoProducer",$"Exceção: {ex.GetType().FullName} | " + $"Mensagem: {ex.Message}"));
                
            }

            return _response;
        }

        private string ConvertPedidoToJson(CriadoOperacaoEvento operacaoRequest) =>
            JsonConvert.SerializeObject(operacaoRequest);
    }
}