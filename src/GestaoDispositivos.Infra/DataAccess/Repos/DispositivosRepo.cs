using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using Microsoft.EntityFrameworkCore;
namespace GestaoDispositivos.Infra.DataAccess.Repos;

internal class DispositivosRepo : IDispositivoRead, IDispositivoCreate, IDispositivoUpdate, IDispositivoDelete
{
    private readonly GestaoDispositivosDbContext _dbContext;
  
    public DispositivosRepo(GestaoDispositivosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Dispositivo dispositivo)
    {
        await _dbContext.Dispositivos.AddAsync(dispositivo);
    }

    public async Task<bool> Exists(string serial)
    {
        return await _dbContext.Dispositivos.AnyAsync(d => d.Serial.Equals(serial));
    }

    public async Task<List<Dispositivo>> GetAll(Cliente cliente)
    {
        return await _dbContext.Dispositivos.AsNoTracking().Where(dispositivo => dispositivo.ClienteId == cliente.Id).ToListAsync();
    }


    public async Task Delete(Guid id)
    {
        var result = await _dbContext.Dispositivos.FindAsync(id);
        _dbContext.Dispositivos.Remove(result!);
    }

    public void Update(Dispositivo dispositivo)
    {
        _dbContext.Dispositivos.Update(dispositivo);
    }

     async Task<Dispositivo?> IDispositivoRead.GetById(Cliente cliente, Guid id)
     {
        return await _dbContext.Dispositivos
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id && d.ClienteId == cliente.Id);
    }

    async Task<Dispositivo?> IDispositivoRead.VerifyIfExists(Guid id)
    {
        return await _dbContext.Dispositivos
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
    }

}
