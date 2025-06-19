using FluentValidation;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Dispositivos;
public class DispositivoValidator : AbstractValidator<RequestDispositivo>
{
    public DispositivoValidator()
    {
        RuleFor(dispositivo => dispositivo.Serial).MinimumLength(50).WithMessage(ResourceErrorMessages.Serial_Not_Empty);
        RuleFor(dispositivo => dispositivo.IMEI).MinimumLength(15).WithMessage(ResourceErrorMessages.IMEI_Not_Empty);
         }
}