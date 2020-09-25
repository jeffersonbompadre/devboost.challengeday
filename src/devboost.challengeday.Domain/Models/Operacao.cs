namespace devboost.challengeday.Domain.Models
{
    using System;

    using devboost.challengeday.Domain.Enum;

    public class Operacao : Entidade
    {
        public DateTime DataHora { get; set; }

        public TipoTransacao Tipo { get; set; }

        public decimal Valor { get; set; }

        public void ObterTransacao()
        {
            switch (this.Tipo)
            {
                case TipoTransacao.Saque:
                    this.Valor *= -1;
                    break;
                case TipoTransacao.Deposito:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}