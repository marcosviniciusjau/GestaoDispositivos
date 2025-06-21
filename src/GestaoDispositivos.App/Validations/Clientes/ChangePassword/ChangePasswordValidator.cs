using FluentValidation;
using GestaoDispositivos.Communication.Requests;

namespace GestaoDispositivos.App.Validations.Clientes.ChangePassword;
public class ChangePasswordValidator : AbstractValidator<RequestChangePassword>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.NewPassword).SetValidator(new PasswordValidator<RequestChangePassword>());
    }
}
