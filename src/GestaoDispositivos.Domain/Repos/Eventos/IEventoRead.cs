using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Eventos;
public interface IEventoRead
{
    Task<List<Evento>> GetAll();
    Task<List<Evento>> GetEventsByWeek(DateOnly date);
}
