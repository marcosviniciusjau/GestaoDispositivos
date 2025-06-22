using GestaoDispositivos.App.Validations.Eventos.Delete;
using GestaoDispositivos.App.Validations.Eventos.GetAll;
using GestaoDispositivos.App.Validations.Eventos.GetById;
using GestaoDispositivos.App.Validations.Eventos.GetEventoByDispositivoId;
using GestaoDispositivos.App.Validations.Eventos.Register;
using GestaoDispositivos.App.Validations.Eventos.Update;
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

    [HttpGet("get_all_eventos_by_week")]
    [ProducesResponseType(typeof(ResponseEventos), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllEventos([FromServices] IGetAllEventosValidation validation)
    {
        var response = await validation.Execute();

            return Ok(response);

    }

    [HttpGet("evento_by_dispositivo_id")]
    [ProducesResponseType(typeof(ResponseEventos), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<IActionResult> GetEventoByDispositivoId([FromServices] IGetEventoByDispositivoIdValidation validation, [FromQuery] Guid dispositivoId)
    {
        var response = await validation.Execute(dispositivoId);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseEvento), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
   [FromServices] IGetByIdValidation validation,
   [FromRoute] Guid id)
    {
        var response = await validation.Execute(id);

        return Ok(response);
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
