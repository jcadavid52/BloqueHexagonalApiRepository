using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCamiloCadavid.App.RolePersonUseCases.CreateRolePerson;

namespace PruebaTecnicaCamiloCadavid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePersonController(IMediator mediator) : ControllerBase
    {
        [HttpPost("create-rol-person")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateRolePerson([FromBody] CreateRolePersonCommand command)
        {
            await mediator.Send(command);

            return Created("", new { id = 1 });
        }
    }
}
