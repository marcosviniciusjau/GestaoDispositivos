using GestaoDispositivos.App.Validations.Eventos.GetAll;
using GestaoDispositivos.App.Validations.Eventos.Register;
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
}
