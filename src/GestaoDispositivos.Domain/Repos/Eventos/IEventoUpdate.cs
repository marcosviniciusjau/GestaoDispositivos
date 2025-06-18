using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Eventos;
public interface IEventoUpdate
{
    void Update(Evento evento);
}
