using AutoMapper;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos.Eventos;
namespace GestaoDispositivos.App.Validations.Eventos.GetByDate;
public class GetEventosByDateValidation : IGetEventosByDateValidation
{
    private readonly IEventoRead _repos;
    private readonly IMapper _mapper;

    public GetEventosByDateValidation(
        IEventoRead repos,
        IMapper mapper
        )
    {
        _repos = repos;
        _mapper = mapper;
    }

    public async Task<List<Evento>> Execute(DateTime date)
    {
        var eventos = await _repos.GetByDate(date);
        return eventos;
      }
}
