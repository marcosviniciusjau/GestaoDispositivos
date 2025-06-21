using GestaoDispositivos.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace GestaoDispositivos.Domain.Repos.Admin;
public interface IAdminRead
{
    Task<bool> Exists(string email);
    Task<Entities.Admin?> GetByEmail(string email);

    Task<List<Cliente>> GetAllClientes(Entities.Admin admin);
}
