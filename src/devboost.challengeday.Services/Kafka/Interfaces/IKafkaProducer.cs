using devboost.challengeday.Domain.Commands.Request;
using System.Threading.Tasks;

namespace devboost.challengeday.Services.Kafka.Interfaces
{
    public interface IKafkaProducer
    {
        Task Operacao(ContaCorrenteRequest contaCorrenteRequest);
    }
}
