using devboost.challengeday.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.challengeday.Domain.Commands.Request
{
    public class OperacaoRequest
    {
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
    }
}
