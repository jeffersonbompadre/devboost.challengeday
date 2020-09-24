using devboost.challengeday.Domain.Commands.Request;
using System.Threading.Tasks;

namespace devboost.challengeday.Services.Kafka
{
    public interface IProduce
    {
        Task Operacao(ContaCorrenteRequest contaCorrenteRequest);
    }
}
