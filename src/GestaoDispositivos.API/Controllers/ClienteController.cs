using GestaoDispositivos.App.Validations.Users.ChangePassword;
using GestaoDispositivos.App.Validations.Users.Delete;
using GestaoDispositivos.App.Validations.Users.GetProfile;
using GestaoDispositivos.App.Validations.Users.Register;
using GestaoDispositivos.App.Validations.Users.Update;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDispositivos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegistrarClienteValidation validation,
            [FromBody] RequestCliente request)
        {
            var response = await validation.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseClienteProfile), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetProfile([FromServices] IGetProfileValidation validation)
        {
            var response = await validation.Execute();

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProfile(
            [FromServices] IUpdateProfileValidation validation,
            [FromBody] RequestUpdateCliente request)
        {
            await validation.Execute(request);

            return NoContent();
        }

        [HttpPut("change-password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePassword(
                [FromServices] IChangePasswordValidation validation,
                [FromBody] RequestChangePassword request)
        {
            await validation.Execute(request);

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<IActionResult> DeleteProfile([FromServices] IDeleteProfileValidation validation)
        {
            await validation.Execute();

            return NoContent();
        }
    }
}