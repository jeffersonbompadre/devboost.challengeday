using devboost.challengeday.Shared.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace devboost.challengeday.Services.Commands.Request
{
    public class OperacaoRequest: Notifiable
    {
        public Guid IdTransaction { get; set;}
        public decimal Valor { get; set; }
        public TipoTransacao Operacao { get; set; }
        public DateTime? DataHora { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                  .Requires()
                  .IsGreaterThan(Valor, 0, nameof(Valor), "O valor da transação tem que ser maior que zero"));
            
        }
    }
}
