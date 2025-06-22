using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos.Clientes;
using Microsoft.EntityFrameworkCore;

namespace GestaoDispositivos.Infra.DataAccess.Repos;

internal class ClientesRepo(GestaoDispositivosDbContext dbContext) : IClienteRead, IClienteCreate, IClienteUpdate, IClienteDelete
{
    private readonly GestaoDispositivosDbContext _dbContext = dbContext;

    public async Task Add(Cliente cliente)
    {
        await _dbContext.Clientes.AddAsync(cliente);
    }

    public async Task Delete(Cliente cliente)
    {
        var clienteToRemove = await _dbContext.Clientes.FindAsync(cliente.Id);
        _dbContext.Clientes.Remove(clienteToRemove!);
    }

    public async Task<bool> Exists(string email)
    {
        return await _dbContext.Clientes.AnyAsync(c=> c.Email.Equals(email));
    }

    public async Task<Cliente?> GetByEmail(string email)
    {
        return await _dbContext.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email.Equals(email));
    }

    public async Task<Cliente> GetById(Guid id)
    {
        return await _dbContext.Clientes.FirstAsync(cliente => cliente.Id == id);
    }

    public void Update(Cliente cliente)
    {
        _dbContext.Clientes.Update(cliente);
    }
}
