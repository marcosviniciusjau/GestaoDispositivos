namespace GestaoDispositivos.Domain.Repos;
public interface IUnitOfWork
{
    Task Commit();
}
