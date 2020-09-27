using devboost.challengeday.Services.Kafka.Interfaces;
using devboost.challengeday.Shared.Event;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.challengeday.ProducerAPI.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
       public class EnviarOperacaoController : ControllerBase
       {
        private readonly IKafkaProducer _produce;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produce"></param>
        public EnviarOperacaoController(IKafkaProducer produce)
        {
            _produce = produce;
        }


        /// <summary>
        /// Criar transação 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/operacaoasync
        ///     {
        ///        "operação": 1,
        ///        "valor": 999
        ///     }
        ///      
        ///     Operacao 
        ///     {
        ///      
        ///       1 Saque
        ///       2 Deposito
        ///     }
        /// </remarks>        
        /// <param name="criadoOperacaoEvento"></param>  
        [HttpPost("Operacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> OperecaoAsync([FromBody] CriadoOperacaoEvento criadoOperacaoEvento)
        {
            var RESULT = await _produce.OperacaoAsync(criadoOperacaoEvento);

            if (RESULT.HasFails) {

                return BadRequest(RESULT.Fails);
            }

            return Ok(RESULT.Data);
        }
    }
}
