using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCamiloCadavid.App.AddressUseCases.Create;
using PruebaTecnicaCamiloCadavid.App.AddressUseCases.GetAll;
using PruebaTecnicaCamiloCadavid.App.PersonUseCases.GetAll;

namespace PruebaTecnicaCamiloCadavid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await mediator.Send(new GetAllRoleQuery());

            return Ok(addresses);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] CreateAddressCommand command)
        {
            var id = await mediator.Send(command);

            return Created("", new { id });
        }
    }
}
