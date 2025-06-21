using FluentValidation;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Eventos;
public class EventoValidator : AbstractValidator<RequestEvento>
{
    public EventoValidator()
    {
        RuleFor(evento => evento.DataHora).NotEmpty().WithMessage(ResourceErrorMessages.Date_Not_Empty);
        
        RuleFor(evento => evento.Tipo).IsInEnum().WithMessage(ResourceErrorMessages.Type_Invalid);

        RuleFor(evento => evento.DispositivoId).NotEmpty().WithMessage(ResourceErrorMessages.Dispositivo_Id_Not_Empty);
    }

}