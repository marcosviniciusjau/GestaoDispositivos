using GestaoDispositivos.App.Validations.Login;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDispositivos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCliente), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Register(
            [FromServices] ILoginValidation validation,
            [FromBody] RequestLogin request)
    {
        var response = await validation.Execute(request);

        return Created(string.Empty, response);
    }
}

