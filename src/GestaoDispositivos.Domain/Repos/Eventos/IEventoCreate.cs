using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Eventos;
public interface IEventoCreate
{
    Task Add(Evento evento);
}
