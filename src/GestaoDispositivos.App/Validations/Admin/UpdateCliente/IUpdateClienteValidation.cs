using GestaoDispositivos.Communication.Requests;

namespace GestaoDispositivos.App.Validations.Admin.UpdateCliente;
public interface IUpdateClienteValidation
{

    public Task Execute(Guid clienteId,RequestUpdateCliente request);
}
