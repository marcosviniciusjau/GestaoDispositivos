using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Clientes.Register;
public interface IRegisterClienteValidation
{
    Task<ResponseUser> Execute(RequestCliente request);
}
