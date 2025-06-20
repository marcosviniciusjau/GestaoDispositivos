using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Dispositivos;
public interface IDispositivoRead
{
    Task<List<Dispositivo>> GetAll(Cliente cliente);
    Task<Dispositivo?> VerifyIfExists(Guid dispositivoId);

    Task<Dispositivo?> GetById(Cliente cliente, Guid dispositivoId);
}

