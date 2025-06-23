using FluentValidation;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Clientes.Update;

internal class UpdateProfileValidator : AbstractValidator<RequestUpdateProfile>
{
    public UpdateProfileValidator()
    {
        RuleFor(profile => profile.Nome).NotEmpty().WithMessage(ResourceErrorMessages.Name_Not_Empty);
        RuleFor(profile => profile.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.Email_Not_Empty)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourceErrorMessages.Email_Invalid);
    }
}