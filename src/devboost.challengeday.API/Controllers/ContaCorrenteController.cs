namespace devboost.challengeday.API.Controllers
{
    using System;
    using System.Threading.Tasks;

  
    using devboost.challengeday.Services.Commands.Request;
    using devboost.challengeday.Services.Interfaces;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    public class ContaCorrenteController : BaseController
    {
        private readonly IOperacaoService _operacaoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operacaoService"></param>
        public ContaCorrenteController(IOperacaoService operacaoService)
        {
            _operacaoService = operacaoService;
        }

        /// <summary>
        /// Solicita o saldo
        /// </summary>
        /// <remarks>
        /// </remarks>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _operacaoService.SaldoAsync();

            if (result.HasFails) return BadRequest(result.Fails);

            return Ok(result.Data);
        }

        /// <summary>
        /// Criar Operação 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/operacaoasync
        ///     {
        ///        "operação": 1,
        ///        "valor": 999,
        ///        "Id":    
        ///     }
        ///     
        ///     Operacao 
        ///      {
        ///       
        ///        1 Saque
        ///        2 Deposito
        ///      }
        /// </remarks>        
        /// <param name="operacaoRequest"></param>  
        [HttpPost("Operacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> OperacaoAsync([FromBody] OperacaoRequest operacaoRequest)
        {
            var result = await _operacaoService.OperacaoAsync(operacaoRequest);

            if (result.HasFails) return BadRequest(result.Fails);

            return this.Ok(result.Data);
           
        }
    }
}