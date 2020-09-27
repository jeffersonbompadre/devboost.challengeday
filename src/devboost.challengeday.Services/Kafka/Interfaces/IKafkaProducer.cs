using devboost.challengeday.Shared.Event;
using devboost.challengeday.Shared.Response;
using System.Threading.Tasks;

namespace devboost.challengeday.Services.Kafka.Interfaces
{
    public interface IKafkaProducer
    {
        Task<ResponseResult> OperacaoAsync(CriadoOperacaoEvento criadoOperacaoEvento);
    }
}
