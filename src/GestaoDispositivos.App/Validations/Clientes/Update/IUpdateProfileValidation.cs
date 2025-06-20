using GestaoDispositivos.Communication.Requests;

namespace GestaoDispositivos.App.Validations.Users.Update;
public interface IUpdateProfileValidation
{

    public Task Execute(RequestUpdateCliente request);
}
