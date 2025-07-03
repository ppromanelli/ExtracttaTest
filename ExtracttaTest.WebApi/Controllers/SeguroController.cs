using ExtracttaTest.Application.Features.SeguroFeatures.Commands;
using ExtracttaTest.Application.Features.SeguroFeatures.Dtos;
using ExtracttaTest.Application.Features.SeguroFeatures.Queries;
using ExtracttaTest.Application.Features.VeiculoFeatures.Commands;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using ExtracttaTest.Application.Features.VeiculoFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExtracttaTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeguroController : ControllerBase
    {
        private IMediator _mediatorInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();


        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new SeguroGetQuery(id));

            if (result.Data == null)
                return NotFound();

            return Ok(result.Data);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new SeguroListQuery());

            if (result.Data == null)
                return NotFound();

            return Ok(result.Data);
        }

        [HttpGet("mediaAritmetica")]
        public virtual async Task<IActionResult> MediaAritmetica([FromQueryAttribute] string? filter = null)
        {
            var result = await _mediator.Send(new SeguroMediaAritmeticaQuery(filter));

            if (result.Data == null)
                return NotFound();

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeguroCreateDto createDto)
        {
            var result = await _mediator.Send(new SeguroCreateCommand(createDto));

            if (result.Data == default(int))
                return BadRequest();

            createDto.Id = result.Data;

            var resultDto = await _mediator.Send(new SeguroGetQuery(result.Data));

            return CreatedAtAction(nameof(Get), new { id = result.Data }, resultDto.Data);
        }
    }
}
