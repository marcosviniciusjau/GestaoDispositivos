using FluentValidation;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Clientes.Register;
public class ClienteValidator : AbstractValidator<RequestCliente>
{
    public ClienteValidator()
    {
        RuleFor(cliente => cliente.Nome).NotEmpty().WithMessage(ResourceErrorMessages.Name_Not_Empty);
        RuleFor(cliente => cliente.Status).NotEmpty().WithMessage(ResourceErrorMessages.Status_Invalid);
        RuleFor(cliente => cliente.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.Email_Not_Empty)
            .EmailAddress()
            .WithMessage(ResourceErrorMessages.Email_Invalid)
            ;
        RuleFor(cliente => cliente.Senha).SetValidator(new PasswordValidator<RequestCliente>());

    }
}