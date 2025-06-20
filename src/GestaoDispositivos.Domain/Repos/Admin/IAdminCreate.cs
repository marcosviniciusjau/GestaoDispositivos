using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Admin;
public interface IAdminCreate
{
    Task Add(Entities.Admin admin);
}
