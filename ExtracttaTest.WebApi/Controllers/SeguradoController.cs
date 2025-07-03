using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Commands;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Features.SeguradoFeatures.Queries;
using ExtracttaTest.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExtracttaTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeguradoController : ControllerBase
    {
        private IMediator _mediatorInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new SeguradoGetQuery(id));

            if (result.Data == null)
                return NotFound();

            return Ok(result.Data);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new SeguradoListQuery());

            if (result.Data == null)
                return NotFound();

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeguradoCreateDto createDto)
        {
            var result = await _mediator.Send(new SeguradoCreateCommand(createDto));

            if (result.Data == default(int))
                return BadRequest();

            createDto.Id = result.Data;
            return CreatedAtAction(nameof(Get), new { id = result.Data }, createDto);
        }
    }
}
