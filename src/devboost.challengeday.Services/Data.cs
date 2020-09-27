using devboost.challengeday.Shared.Enums;
using System;

namespace devboost.challengeday.Services
{
    internal class Data
    {
        public string Transacao { set; get; }

        public Guid IdTransacao { set; get; }

        public string Mensagem { set; get; }

        public decimal Valor { set; get; }

    }
}