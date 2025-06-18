using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Clientes;
public interface IClienteUpdate
{
    Task<bool> ExistCliente(string email);
    Task<Cliente> GetById(Guid id);
    void Update(Cliente cliente);
}
