using GestaoDispositivos.Communication.Requests;

namespace GestaoDispositivos.App.Validations.Clientes.Update;
public interface IUpdateProfileValidation
{

    public Task Execute(RequestUpdateProfile request);
}
