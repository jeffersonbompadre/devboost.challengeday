using devboost.challengeday.Services.Commands.Request;
using System.Threading.Tasks;

namespace devboost.challengeday.Kafka.Interfaces
{
    public interface ITransactionHttpFactory
    {
        Task<bool> Trasaction(OperacaoRequest contacorrenteRequest);
    }
}
