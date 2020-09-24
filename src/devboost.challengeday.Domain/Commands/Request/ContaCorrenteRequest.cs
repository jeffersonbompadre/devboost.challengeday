using devboost.challengeday.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.challengeday.Domain.Commands.Request
{
    public class ContaCorrenteRequest
    {
        public DateTime DAtaHora { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
    }
}
