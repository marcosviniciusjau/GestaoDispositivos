using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.App.Validations.Eventos.GetEventoByDispositivoId;
public interface IGetEventoByDispositivoIdValidation
{
    Task<ResponseEvento> Execute(Guid dispositivoId);
}