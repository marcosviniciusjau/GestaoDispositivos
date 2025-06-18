using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Entities.Enums;
using GestaoDispositivos.Domain.Repos.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.SqlServer.Management.Smo;
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


    public async Task<List<Evento>> GetEventsByWeek(DateOnly date)
    {
        var startDate = 11/06/2025;
        var endDate =18/06/2025;

        return await _dbContext.Eventos.AsNoTracking()
            .OrderByDescending(evento => evento.DataHora)
            .ToListAsync();
    }


    public async Task Delete(Guid id)
    {
        var result = await _dbContext.Eventos.FindAsync(id);
        _dbContext.Eventos.Remove(result!);
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

  //  private static IIncludableQueryable<Evento, ICollection<Tipos>> GetFullEvento()
  //  {
      // return _dbContext.Eventos
         //   .Include(eventos => eventos.Tipo);
  //  }
}
