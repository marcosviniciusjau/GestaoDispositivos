using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos.Eventos;
using Microsoft.EntityFrameworkCore;
namespace GestaoDispositivos.Infra.DataAccess.Repos;

internal class EventosRepo(GestaoDispositivosDbContext dbContext) : IEventoRead, IEventoCreate, IEventoUpdate, IEventoDelete
{
    private readonly GestaoDispositivosDbContext _dbContext = dbContext;
  
    public async Task Add(Evento evento)
    {
    
        await _dbContext.Eventos.AddAsync(evento);
    }

 
    public async Task<List<Evento>> GetAll()
    {
        return await _dbContext.Eventos.AsNoTracking().ToListAsync();
    }

    public async Task Delete(Guid id)
    {
        var result = await _dbContext.Eventos.FindAsync(id);
        _dbContext.Eventos.Remove(result!);
    }

    async Task<Evento?> IEventoRead.GetByDispositivoId(Guid dispositivoId)
    {
        return await _dbContext.Eventos
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DispositivoId == dispositivoId);
    }

    public async Task<List<EventosByTipo>> GetEventsByWeek()
    {
        var today =  DateTime.UtcNow;
        var startOfWeek = DateTime.UtcNow.AddDays(-7);
 
        var eventosByCategory = 
            await _dbContext.Eventos
            .AsNoTracking()
            .Where(e => e.DataHora >= startOfWeek &&
             e.DataHora <= today)
            .GroupBy(e => e.Tipo)
            .Select(grp => new EventosByTipo
            {
                Tipo = grp.Key,
                Eventos = grp.ToList(),
                Quantidade = grp.Count()
            })
            .ToListAsync();

        return eventosByCategory;
    }
 
    public void Update(Evento evento)
    {
        _dbContext.Eventos.Update(evento);
    }

    async Task<Evento?> IEventoRead.GetById(Guid id)
    {
        return await _dbContext.Eventos
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

}
