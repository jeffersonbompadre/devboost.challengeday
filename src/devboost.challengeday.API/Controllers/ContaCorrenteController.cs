using devboost.challengeday.Domain.Commands.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.challengeday.API.Controllers
{
    [ApiVersion("1.0")]
    public class ContaCorrenteController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //todo: trazer do mongo
            return Ok("saldo");
        }

        [HttpPost("Depositar")]
        public async Task<ActionResult> Depositar([FromBody] ContaCorrenteRequest contaCorrenteRequest)
        {
            //todo: mandar para o kafka
            return Ok("deposito efetuado");
        }

        [HttpPost("Sacar")]
        public async Task<ActionResult> Sacar([FromBody] ContaCorrenteRequest contaCorrenteRequest)
        {
            //todo: mandar para o kafka
            return Ok("deposito efetuado");
        }
    }
}
