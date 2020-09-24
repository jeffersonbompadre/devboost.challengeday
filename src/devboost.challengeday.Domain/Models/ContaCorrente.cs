using devboost.challengeday.Domain.Enum;
using System;

namespace devboost.challengeday.Domain.Models
{
    public class ContaCorrente : Entidade
    {
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
    }
}
