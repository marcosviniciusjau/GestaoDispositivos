using GestaoDispositivos.Communication.Requests;

namespace GestaoDispositivos.App.Validations.Clientes.ChangePassword;
public interface IChangePasswordValidation
{
    Task Execute(RequestChangePassword request);
}
