using devboost.challengeday.Domain.Commands.Request;
using devboost.challengeday.Services.Kafka.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.challengeday.ProducerAPI.Controllers
{
    [ApiVersion("1.0")]
    public class EnviarOperacaoController : ControllerBase
    {
        private readonly IKafkaProducer _produce;

        public EnviarOperacaoController(IKafkaProducer produce)
        {
            _produce = produce;
        }

        [HttpPost("Operecao")]
        public async Task<ActionResult> Operecao([FromBody] ContaCorrenteRequest contaCorrenteRequest)
        {
            await _produce.Operacao(contaCorrenteRequest);
            return Ok("deposito efetuado");
        }
    }
}
