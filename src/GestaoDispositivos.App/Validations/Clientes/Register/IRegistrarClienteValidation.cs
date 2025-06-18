using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Users.Register;
public interface IRegistrarClienteValidation
{
    Task<ResponseCliente> Execute(RequestCliente request);
}
