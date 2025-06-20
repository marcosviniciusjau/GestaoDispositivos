using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Admin.GetAll;
public interface IGetAllClientesValidation
{
    Task<ResponseClientes> Execute();
}
