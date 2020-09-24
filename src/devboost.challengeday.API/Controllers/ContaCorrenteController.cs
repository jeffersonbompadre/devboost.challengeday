using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devboost.challengeday.Domain.Commands.Request;
using Microsoft.AspNetCore.Mvc;

namespace devboost.challengeday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("saldo");
        }

        [HttpPost("depositar")]
        public async Task<ActionResult> depositar([FromBody] ContaCorrenteRequest contaCorrenteRequest)
        {
            return Ok("deposito efetuado");
        }

        [HttpPost("sacar")]
        public async Task<ActionResult> sacar([FromBody] ContaCorrenteRequest contaCorrenteRequest)
        {
            return Ok("deposito efetuado");
        }
    }
}
