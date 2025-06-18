using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Clientes;
public interface IClienteCreate
{
    Task Add(Cliente cliente);
}
