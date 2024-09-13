using Abc.Application.Dtos;
using Abc.Application.Features.Empleados.Commands.Crear;
using Abc.Application.Features.Empleados.Queries.Obtener;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Abc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<EmpleadoDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetProducts()
        {
            var query = new ObtenerEmpleadoListQuery();
            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CrearEmpleadoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
