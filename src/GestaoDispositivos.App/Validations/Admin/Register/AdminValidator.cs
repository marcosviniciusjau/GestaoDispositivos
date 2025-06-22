using FluentValidation;
using GestaoDispositivos.App.Validations.Clientes;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Admin.Register;
public class AdminValidator : AbstractValidator<RequestAdmin>
{
    public AdminValidator()
    {
        RuleFor(admin => admin.Nome).NotEmpty().WithMessage(ResourceErrorMessages.Name_Not_Empty);
         RuleFor(admin => admin.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.Email_Not_Empty)
            .EmailAddress()
            .WithMessage(ResourceErrorMessages.Email_Invalid)
            ;
        RuleFor(admin => admin.Senha).SetValidator(new PasswordValidator<RequestAdmin>());

    }
}