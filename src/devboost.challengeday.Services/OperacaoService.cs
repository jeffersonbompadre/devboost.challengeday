namespace devboost.challengeday.Services
{
    using devboost.challengeday.Domain.Interfaces;
    using devboost.challengeday.Domain.Models;
    using devboost.challengeday.Services.Commands.Request;
    using devboost.challengeday.Services.Interfaces;
    using devboost.challengeday.Shared.Response;
    using Flunt.Notifications;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class OperacaoService : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly ResponseResult      _response;


        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
            _response = new ResponseResult();
        }

        public async Task<ResponseResult> OperacaoAsync(OperacaoRequest operacao)
        {
            try
            {
                operacao.Validate();

                if (operacao.Notifications.Any())
                {
                    _response.AddNotifications(operacao.Notifications);
                    return _response;
                }

                var entidade = new Operacao(operacao.IdTransaction, operacao.Valor, operacao.Operacao, operacao.DataHora);

                entidade.ObterTransacao();

                if (entidade.Notifications.Any())
                {

                    _response.AddNotifications(entidade.Notifications);
                    return _response;
                }


                var transaction = await TransacaoAsync(entidade);

                _response.AddValue(new Data
                {

                    Transacao = operacao.Operacao.ToString(),
                    IdTransacao = operacao.IdTransaction,
                    Mensagem = $"Operação efutuada com sucesso em :{ operacao.DataHora.ToString()}",
                    Valor = transaction

                });
            }
            catch (Exception exception)
            {
                _response.AddNotification( new Notification(nameof(OperacaoService), $"Falha na operação ocorreu uma exceção em :{ exception}"));
                
            }

            return _response;
        }

        private async Task<decimal> CalculeSaldoAsync()
        {
            var contaCorrentes = await _operacaoRepository.GetAllAsync();
            var valor = contaCorrentes.Sum(x => x.Valor);
            return valor;
        }

        public async Task<ResponseResult> SaldoAsync()
        {
            try
            {
                var saldo = await CalculeSaldoAsync();

                _response.AddValue(
                    new
                    {
                        operacao = "Saldo",
                        Mensagem = $"Operação realizada com sucesso { DateTime.Now.ToString()}",
                        Valor    = saldo

                    });
            }
            catch (Exception exception)
            {
                _response.AddNotification(new Notification(nameof(SaldoAsync), $"Falha na operação de getSaldo ocorreu uma exceção em :{ exception}"));

            }

            return _response;
        }

        private async Task<decimal> TransacaoAsync(Operacao entidade)
        {
            await _operacaoRepository.AddAsync(entidade);
            return await CalculeSaldoAsync();
        }
    }
}