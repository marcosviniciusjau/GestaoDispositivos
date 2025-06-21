using GestaoDispositivos.App.Validations.Clientes.Delete;
using GestaoDispositivos.App.Validations.Dispositivos.Delete;
using GestaoDispositivos.App.Validations.Dispositivos.GetAll;
using GestaoDispositivos.App.Validations.Dispositivos.Register;
using GestaoDispositivos.App.Validations.Dispositivos.Update;

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
    public async Task<IActionResult> GetAllDispositivos([FromServices] IGetAllDispositivosValidation validation)
    {
        var response = await validation.Execute();

        if (response.Dispositivos.Count != 0)
            return Ok(response);

        return NoContent();

    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
      [FromServices] IDeleteDispositivoValidation validation,
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
        [FromServices] IUpdateDispositivoValidation validation,
        [FromRoute] Guid id,
        [FromBody] RequestDispositivo request)
    {
        await validation.Execute(id, request);
        return NoContent();

    }

}
