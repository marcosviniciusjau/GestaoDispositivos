using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.App.Validations.Eventos.GetByDate;
public interface IGetEventosByDateValidation
{
    Task<List<Evento>> Execute(DateTime date);
}