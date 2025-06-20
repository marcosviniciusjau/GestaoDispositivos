using GestaoDispositivos.Domain.Entities;


namespace GestaoDispositivos.Domain.Services;
public interface IAdminLogado
{
    Task<Admin> Get();
}