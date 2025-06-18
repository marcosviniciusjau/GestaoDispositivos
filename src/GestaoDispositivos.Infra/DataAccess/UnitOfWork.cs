using GestaoDispositivos.Domain.Repos;

namespace GestaoDispositivos.Infra.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly GestaoDispositivosDbContext _dbContext;
    public UnitOfWork(GestaoDispositivosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
    
}
