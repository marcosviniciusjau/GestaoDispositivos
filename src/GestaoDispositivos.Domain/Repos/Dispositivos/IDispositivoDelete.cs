using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Dispositivos;
public interface IDispositivoDelete
{
    Task Delete(Guid id);
}
