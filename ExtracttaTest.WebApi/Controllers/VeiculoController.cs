using ExtracttaTest.Application.Features.SeguradoFeatures.Commands;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Features.SeguradoFeatures.Queries;
using ExtracttaTest.Application.Features.VeiculoFeatures.Commands;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using ExtracttaTest.Application.Features.VeiculoFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExtracttaTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private IMediator _mediatorInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();


        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new VeiculoGetQuery(id));

            if (result.Data == null)
                return NotFound();

            return Ok(result.Data);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new VeiculoListQuery());

            if (result.Data == null)
                return NotFound();

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VeiculoCreateDto createDto)
        {
            var result = await _mediator.Send(new VeiculoCreateCommand(createDto));

            if (result.Data == default(int))
                return BadRequest();

            createDto.Id = result.Data;
            return CreatedAtAction(nameof(Get), new { id = result.Data }, createDto);
        }

        [HttpPost("calculaSeguro")]
        public async Task<IActionResult> CalculaValorSeguro([FromBody] VeiculoCalculaSeguroDto dto)
        {
            var result = await _mediator.Send(new VeiculoCalculaSeguroQuery(dto));

            return Ok(result.Data);
        }
    }
}
