namespace devboost.challengeday.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using devboost.challengeday.Domain.Commands.Request;
    using devboost.challengeday.Domain.Enum;
    using devboost.challengeday.Domain.Interfaces;
    using devboost.challengeday.Domain.Models;

    using ServiceStack;

    public class OperacaoService : IOperacaoService
    {
        private readonly IOperacaoRepository operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            this.operacaoRepository = operacaoRepository;
        }

        public async Task<decimal> Deposito(OperacaoRequest operacao)
        {
            var entidade = operacao.ConvertTo<Operacao>();
            entidade.Tipo = TipoTransacao.Deposito;
            return await this.Transacao(entidade);
        }

        public async Task<decimal> Saldo()
        {
            var contaCorrentes = await this.operacaoRepository.GetAll();
            var valor = contaCorrentes.Sum(x => x.Valor);

            return valor;
        }

        public async Task<decimal> Saque(OperacaoRequest operacao)
        {
            var entidade = operacao.ConvertTo<Operacao>();
            entidade.Tipo = TipoTransacao.Saque;
            return await this.Transacao(entidade);
        }

        private async Task<decimal> Transacao(Operacao entidade)
        {
            entidade.ObterTransacao();

            await this.operacaoRepository.Save(entidade);
            return await this.Saldo();
        }
    }
}