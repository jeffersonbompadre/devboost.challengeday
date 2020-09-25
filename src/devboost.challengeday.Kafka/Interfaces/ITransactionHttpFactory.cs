using devboost.challengeday.Domain.Commands.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.challengeday.Kafka.Interfaces
{
    public interface ITransactionHttpFactory
    {
        Task<bool> Trasaction(OperacaoRequest contacorrenteRequest);
    }
}
