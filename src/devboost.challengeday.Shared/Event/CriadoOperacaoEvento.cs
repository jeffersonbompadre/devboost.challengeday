using devboost.challengeday.Shared.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace devboost.challengeday.Shared.Event
{
    public class CriadoOperacaoEvento: Notifiable
    {
        public Guid IdTransacao { get; private set; }
        public decimal Valor { get; set; }
        public TipoTransacao Operacao { get; set; }

        public DateTime? DataHora { get; private set; } 

        public CriadoOperacaoEvento()
        {
            IdTransacao= Guid.NewGuid();
            DataHora = DateTime.Now;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                  .Requires()
                  .IsGreaterThan(Valor, 0, nameof(Valor), "O valor da transação tem que ser maior que zero"));


            AddNotifications(new Contract()
                  .Requires()
                  .IsNotNull(Operacao, nameof(Operacao), " A operação não pode  ser nula"));
            

         

          




        }
    }
}
