using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestaoDispositivos.Infra.DataAccess.Repos;

internal class AdminRepo(GestaoDispositivosDbContext dbContext) : IAdminRead, IAdminCreate, IAdminDelete
{
    private readonly GestaoDispositivosDbContext _dbContext = dbContext;

    public async Task Add(Admin admin)
    {
        await _dbContext.Admin.AddAsync(admin);
    }

    public async Task Delete(Admin admin)
    {
        var adminToRemove = await _dbContext.Admin.FindAsync(admin.Id);
        _dbContext.Admin.Remove(adminToRemove!);
    }

    public async Task<bool> Exists(string email)
    {
        return await _dbContext.Admin.AnyAsync(u => u.Email.Equals(email));
    }

    public async Task<List<Cliente>> GetAllClientes(Admin admin)
    {
        return await _dbContext.Clientes.AsNoTracking().ToListAsync();
    }


    public async Task<Admin?> GetByEmail(string email)
    {
        return await _dbContext.Admin
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email.Equals(email));
    }
}
