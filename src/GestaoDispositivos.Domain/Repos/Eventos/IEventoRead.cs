using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Eventos;
public interface IEventoRead
{
    Task<List<Evento>> GetAll();
    Task<Evento?> GetByDispositivoId(Guid dispositivoId);

    Task<Evento?> GetById(Guid id);
    Task<List<Evento>> GetByDate(DateTime date);

    Task<List<EventosByTipo>> GetEventsByWeek();
}
