using FluentValidation;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Clientes.Update;

internal class UpdateUserValidator : AbstractValidator<RequestUpdateCliente>
{
    public UpdateUserValidator()
    {
        RuleFor(expense => expense.Nome).NotEmpty().WithMessage(ResourceErrorMessages.Name_Not_Empty);
        RuleFor(expense => expense.Telefone).NotEmpty().WithMessage(ResourceErrorMessages.Name_Not_Empty);
        RuleFor(expense => expense.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.Email_Not_Empty)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourceErrorMessages.Email_Invalid);
    }
}