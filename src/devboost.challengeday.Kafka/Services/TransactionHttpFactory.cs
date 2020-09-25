using devboost.challengeday.Kafka.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace devboost.challengeday.Kafka.Services
{
    public class TransactionHttpFactory : ITransactionHttpFactory
    {

        private readonly HttpClient _client;

        public TransactionHttpFactory(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("contacorrente");
        }

        public async Task<bool> Trasaction(ContaCorrenteRequest contacorrenteRequest)
        {
            var response = await _client.PostAsJsonAsync("/api/pedidos", contacorrenteRequest);
            return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
        }
    }
}
