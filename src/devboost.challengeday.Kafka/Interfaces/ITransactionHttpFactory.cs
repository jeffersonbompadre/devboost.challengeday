using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.challengeday.Kafka.Interfaces
{
    public interface ITransactionHttpFactory
    {
        Task<bool> Trasaction(ContaCorrenteRequest contacorrenteRequest);
    }
}
