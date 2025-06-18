using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Dispositivos;
public interface IDispositivoCreate
{
    Task Add(Dispositivo dispositivo);
}
