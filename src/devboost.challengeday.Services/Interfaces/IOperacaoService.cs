namespace devboost.challengeday.Services.Interfaces
{
    using devboost.challengeday.Services.Commands.Request;
    using devboost.challengeday.Shared.Response;
    using System.Threading.Tasks;

    public interface IOperacaoService
    {

        Task<ResponseResult> OperacaoAsync(OperacaoRequest operacao);
        
        Task<ResponseResult> SaldoAsync();

    }
}