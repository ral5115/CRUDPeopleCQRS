using CRUDPersonCleanArchitecture.Commands;
using CRUDPersonCleanArchitecture.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUDPersonCleanArchitecture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene todas las personas en el catálogo.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                var result = await _mediator.Send(new GetAllPeopleQuery());
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }


        /// <summary>
        /// Crea una nueva persona en el catálogo.
        /// </summary>
        /// <param name="command">Los detalles de la persona a crear.</param>
        [HttpPost]
        public async Task<IActionResult> CreatePeople(CreatePersonCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllPeople), new { id }, command);
        }

        // PUT: api/Person/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] UpdatePersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Person ID mismatch.");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/Person/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _mediator.Send(new DeletePersonCommand { Id = id });
            return NoContent();
        }
    }

}
