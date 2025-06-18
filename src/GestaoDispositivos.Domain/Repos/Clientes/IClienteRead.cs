using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Clientes;
public interface IClienteRead
{
    Task<bool> Exists(string email);
    Task<Cliente?> GetByEmail(string email);
}
