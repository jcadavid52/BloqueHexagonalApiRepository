using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCamiloCadavid.App.RoleUseCases.GetAll;

namespace PruebaTecnicaCamiloCadavid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var roles = await mediator.Send(new GetAllRoleQuery());

            return Ok(roles);
        }
    }
}
