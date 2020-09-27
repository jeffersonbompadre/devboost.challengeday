namespace devboost.challengeday.Domain.Models
{
    using devboost.challengeday.Shared.Enums;
    using Flunt.Validations;
    using System;

    public class Operacao : Entidade
    {
        public DateTime? DataHora { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public decimal Valor { get; private set; }
        public Guid IdTransaction { get; }
     
        public Operacao(Guid idTransaction, decimal valor, TipoTransacao operacao, DateTime? dataHora)
        {
            IdTransaction = idTransaction;
            Valor = valor;
            Tipo = operacao;
            DataHora = dataHora;
        }
        public void ObterTransacao() {

            switch (Tipo)
            {
                case TipoTransacao.Saque:
                    Valor *=-1 ;
                    break;
                case TipoTransacao.Deposito:
                    Valor = Valor;
                    break;
                default:
                    AddNotification(nameof(Tipo), "A operação não permitida");
                    break;
            }
                 
        }
       public override void Validate()
        {
          AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Valor, 0, nameof(Valor), "O valor da transação tem que ser maior que zero"));

            AddNotifications(new Contract()
                  .Requires()
                  .IsNotNull(Tipo, nameof(Tipo), " A operação não pode  ser nula"));

          
        }
    }
}