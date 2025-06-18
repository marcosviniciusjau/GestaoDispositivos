using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Clientes;
public interface IClienteDelete
{
    Task Delete(Cliente cliente);
}
