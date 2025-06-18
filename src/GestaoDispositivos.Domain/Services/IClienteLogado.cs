using GestaoDispositivos.Domain.Entities;


namespace GestaoDispositivos.Domain.Services;
public interface IClienteLogado
{
    Task<Cliente> Get();
}