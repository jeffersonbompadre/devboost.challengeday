﻿using System;
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
            //todo: trazer do mongo
            return Ok("saldo");
        }

        [HttpPost("depositar")]
        public async Task<ActionResult> Depositar([FromBody] ContaCorrenteRequest contaCorrenteRequest)
        {
            //todo: mandar para o kafka
            return Ok("deposito efetuado");
        }

        [HttpPost("sacar")]
        public async Task<ActionResult> Sacar([FromBody] ContaCorrenteRequest contaCorrenteRequest)
        {
            //todo: mandar para o kafka
            return Ok("deposito efetuado");
        }
    }
}
