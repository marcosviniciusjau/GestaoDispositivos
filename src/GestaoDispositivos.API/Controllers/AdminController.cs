using GestaoDispositivos.App.Validations.Admin.GetAllClientes;
using GestaoDispositivos.App.Validations.Admin.Register;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDispositivos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseAdmin), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterAdminValidation validation,
            [FromBody] RequestAdmin request)
        {
            var response = await validation.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseClientes), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetClientes([FromServices] IGetAllClientesValidation validation)
        {
            var response = await validation.Execute();

            return Ok(response);
        }

    }
}