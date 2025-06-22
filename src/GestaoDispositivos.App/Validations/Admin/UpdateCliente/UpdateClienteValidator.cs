using FluentValidation;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Admin.UpdateCliente;

internal class UpdateClienteValidator : AbstractValidator<RequestUpdateCliente>
{
    public UpdateClienteValidator()
    {
        RuleFor(cliente => cliente.Status).NotEmpty().WithMessage(ResourceErrorMessages.Status_Invalid);
    }
}