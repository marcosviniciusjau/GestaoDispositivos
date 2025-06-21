using GestaoDispositivos.App.Validations.LoginAdmin;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDispositivos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginAdminController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUser), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Register(
            [FromServices] ILoginValidationAdmin validation,
            [FromBody] RequestLogin request , IConfiguration configuration
        )
    {
        var response = await validation.Execute(request, configuration);

        return Created(string.Empty, response);
    }
}

