using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Repos.Admin;
public interface IAdminDelete
{
    Task Delete(Entities.Admin admin);
}
