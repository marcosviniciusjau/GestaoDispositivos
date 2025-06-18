using GestaoDispositivos.Communication.Requests;

namespace GestaoDispositivos.App.Validations.Users.ChangePassword;
public interface IChangePasswordValidation
{
    Task Execute(RequestChangePassword request);
}
