using FluentValidation;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Eventos;
public class UpdateEventoValidator : AbstractValidator<RequestEvento>
{
    public UpdateEventoValidator()
    {  
        RuleFor(evento => evento.Tipo).IsInEnum().WithMessage(ResourceErrorMessages.Type_Invalid);

     }

    internal object Validate(RequestUpdateEvento request)
    {
        throw new NotImplementedException();
    }
}