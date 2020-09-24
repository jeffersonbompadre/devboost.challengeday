using devboost.challengeday.Domain.Commands.Request;
using devboost.challengeday.Services.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.challengeday.ProducerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviarOperacaoController : ControllerBase
    {
        private readonly IProduce produce;

        public EnviarOperacaoController(IProduce produce)
        {
            this.produce = produce;
        }

        [HttpPost("depositar")]
        public async Task<ActionResult> Operecao([FromBody] ContaCorrenteRequest contaCorrenteRequest)
        {
            await this.produce.Operacao(contaCorrenteRequest);

            return Ok("deposito efetuado");
        }
    }
}
