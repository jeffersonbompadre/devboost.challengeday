namespace devboost.challengeday.Domain.Interfaces
{
    using System.Threading.Tasks;

    using devboost.challengeday.Domain.Commands.Request;
    using devboost.challengeday.Domain.Models;

    public interface IOperacaoService
    {
        Task<decimal> Saque(OperacaoRequest operacao);

        Task<decimal> Deposito(OperacaoRequest operacao);

        Task<decimal> Saldo();

    }
}