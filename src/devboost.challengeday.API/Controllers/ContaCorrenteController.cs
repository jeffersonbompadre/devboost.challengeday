namespace devboost.challengeday.API.Controllers
{
    using System;
    using System.Threading.Tasks;

    using devboost.challengeday.Domain.Commands.Request;
    using devboost.challengeday.Domain.Interfaces;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class ContaCorrenteController : BaseController
    {
        private readonly IOperacaoService _OperacaoService;

        public ContaCorrenteController(IOperacaoService operacaoService)
        {
            this._OperacaoService = operacaoService;
        }

        [HttpPost("Depositar")]
        public async Task<ActionResult> Depositar([FromBody] OperacaoRequest operacaoRequest)
        {
            try
            {
                
                var result = await this._OperacaoService.Deposito(operacaoRequest);

                return this.Ok($"deposito efetuado, saldo Atual -> {result}");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await this._OperacaoService.Saldo();

                return this.Ok($"saldo atual -> {result}");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Sacar")]
        public async Task<ActionResult> Sacar([FromBody] OperacaoRequest operacaoRequest)
        {
            try
            {
                var result = await this._OperacaoService.Saque(operacaoRequest);

                return this.Ok($"saque efetuado, saldo Atual -> {result}");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}