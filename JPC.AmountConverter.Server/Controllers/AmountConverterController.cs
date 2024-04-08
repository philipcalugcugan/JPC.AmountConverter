using JPC.AmountConverter.Application.AmountConverterService;
using JPC.AmountConverter.Application.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPC.AmountConverter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmountConverterController : ControllerBase
    {
        private readonly ILogger<AmountConverterController> _logger;
        private readonly IAmountConverterService _amountConverterService;

        /// <summary>
        /// Amount Converter Controller Constructor which initialized the logging and service used
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="amountConverterService"></param>
        public AmountConverterController(ILogger<AmountConverterController> logger,
            IAmountConverterService amountConverterService)
        {
            _logger = logger;
            _amountConverterService = amountConverterService;
        }

        /// <summary>
        /// Endpoint that converts amount to words using Rapid API. I used external APi to demonstrate service layer and using latest frameworks
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ConvertAmountToWords/{amount}")]
        public async Task<ActionResult<AmountConverterResponseDto>> ConvertToWords(decimal amount, CancellationToken cancellationToken)
        {
            return Ok(await _amountConverterService.GetAmountToWords(amount, cancellationToken));
        }
    }
}
