using GestaoDispositivos.App.Validations.Clientes.Delete;
using GestaoDispositivos.App.Validations.Dispositivos.Delete;
using GestaoDispositivos.App.Validations.Dispositivos.Update;
using GestaoDispositivos.App.Validations.Eventos.GetAll;
using GestaoDispositivos.App.Validations.Eventos.Register;
using GestaoDispositivos.App.Validations.Eventos.Update;
using GestaoDispositivos.App.Validations.Users.Update;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EventoController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseEvento), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Register(
        [FromServices] IRegisterEventoValidation validation,
        [FromBody] RequestEvento request)
    {

          var response = await validation.Execute(request);

          return Created(string.Empty, response);
      
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseEventos), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllEventos([FromServices] IGetAllEventosValidation validation)
    {
        var response = await validation.Execute();

        if (response.Eventos.Count != 0)
            return Ok(response);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
   [FromServices] IDeleteEventoValidation validation,
   [FromRoute] Guid id)
    {
        await validation.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateEventoValidation validation,
        [FromRoute] Guid id,
        [FromBody] RequestEvento request)
    {
        await validation.Execute(id, request);
        return NoContent();

    }

}
