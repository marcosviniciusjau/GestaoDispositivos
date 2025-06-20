using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Repos.Eventos;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace GestaoDispositivos.Infra.DataAccess.Repos;

internal class EventosRepo : IEventoRead, IEventoCreate, IEventoUpdate, IEventoDelete
{
    private readonly GestaoDispositivosDbContext _dbContext;
  
    public EventosRepo(GestaoDispositivosDbContext dbContext)
    {
        _dbContext = dbContext;
    }
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
    public async Task<Evento?> GetByDispositivoId(Guid dispositivoId)
    {
        return await _dbContext.Eventos
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.DispositivoId == dispositivoId);
    }

    public async Task<List<EventosByTipo>> GetEventsByWeek()
    {
        //var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;
        ///var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
        //var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

        var eventos = await _dbContext.Eventos
            .AsNoTracking()
            .ToListAsync();

        var agrupados = eventos
            .GroupBy(e => e.Tipo)
            .Select(g => new EventosByTipo
            {
                Tipo = g.Key,
                Eventos = g.ToList()
            })
            .ToList();

        return agrupados;
    }


    public void Update(Evento expense)
    {
        _dbContext.Eventos.Update(expense);
    }


    public async Task<List<Evento>> FilterByWeek(DateOnly date)
    {
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;
        var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
        var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

        return await _dbContext
            .Eventos
            .AsNoTracking()
            .Where(evento => evento.DataHora >= startDate && evento.DataHora <= endDate)
            .OrderBy(evento => evento.DataHora)
            .ToListAsync();
    }
    async Task<Evento?> IEventoRead.GetById(Guid id)
    {
        return await _dbContext.Eventos
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

}
