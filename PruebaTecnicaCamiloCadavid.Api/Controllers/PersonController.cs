using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCamiloCadavid.App.PersonUseCases.Create;
using PruebaTecnicaCamiloCadavid.App.PersonUseCases.Delete;
using PruebaTecnicaCamiloCadavid.App.PersonUseCases.GetAll;
using PruebaTecnicaCamiloCadavid.App.PersonUseCases.GetById;
using PruebaTecnicaCamiloCadavid.App.PersonUseCases.Update;

namespace PruebaTecnicaCamiloCadavid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var people = await mediator.Send(new GetAllPersonQuery());

            return Ok(people);
        }

        [HttpGet("get-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var people = await mediator.Send(new GetByIdPersonQuery(id));

            return Ok(people);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] CreatePersonCommand command)
        {
            var id = await mediator.Send(command);

            return Created("",new {id});
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id,[FromBody] UpdatePersonCommand command)
        {
            command = command with { Id = id };

            var person = await mediator.Send(command);

            return Ok(person);
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeletePersonCommand(id));

            return NoContent();
        }
    }
}
