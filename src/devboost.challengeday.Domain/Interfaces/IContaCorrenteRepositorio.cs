using devboost.challengeday.Domain.Models;
using System.Threading.Tasks;

namespace devboost.challengeday.Domain.Interfaces
{
    public interface IContaCorrenteRepositorio
    {
        Task Deposito(ContaCorrente contaCorrente);
        Task Saque(ContaCorrente contaCorrente);
        Task<decimal> Saldo(ContaCorrente contaCorrente);
    }
}
