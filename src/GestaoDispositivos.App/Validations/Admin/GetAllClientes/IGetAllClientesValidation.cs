using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Admin.GetAllClientes;
public interface IGetAllClientesValidation
{
    Task<ResponseClientes> Execute();
}
