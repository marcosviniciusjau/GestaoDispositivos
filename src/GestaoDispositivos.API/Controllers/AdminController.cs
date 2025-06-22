using GestaoDispositivos.App.Validations.Admin.GetAllClientes;
using GestaoDispositivos.App.Validations.Admin.Register;
using GestaoDispositivos.App.Validations.Admin.UpdateCliente;
using GestaoDispositivos.App.Validations.Eventos.GetById;
using GestaoDispositivos.App.Validations.Eventos.Update;
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
        [HttpPut]
        [Route("{clienteId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
      [FromServices] IUpdateClienteValidation validation,
      [FromRoute] Guid clienteId,
      [FromBody] RequestUpdateCliente request)
        {
            await validation.Execute(clienteId, request);
            return NoContent();

        }
    }
 }