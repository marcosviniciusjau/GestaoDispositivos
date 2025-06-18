namespace GestaoDispositivos.Domain.Repos.Eventos;
public interface IEventoDelete
{
    Task Delete(Guid id);
}
