using GestaoDispositivos.App.Validations.Dispositivo.Register;
using GestaoDispositivos.App.Validations.Dispositivos.GetAll;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDispositivos.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DispositivoController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseDispositivo), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Register(
        [FromServices] IRegisterDispositivoValidation validation,
        [FromBody] RequestDispositivo request)
    {

          var response = await validation.Execute(request);

          return Created(string.Empty, response);
      
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseDispositivo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllDispositivos([FromServices] IGetAllDispositivoValidation validation)
    {
        var response = await validation.Execute();

           return Ok(response);

    }


}
