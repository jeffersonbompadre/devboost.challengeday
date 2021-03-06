﻿using devboost.challengeday.Services.Commands.Request;
using devboost.challengeday.Kafka.Interfaces;
using System.Net.Http;
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

        public async Task<bool> Trasaction(OperacaoRequest contacorrenteRequest)
        {
            var response = await _client.PostAsJsonAsync("/api/v1/ContaCorrente/Operacao", contacorrenteRequest);
            return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
        }
    }
}
