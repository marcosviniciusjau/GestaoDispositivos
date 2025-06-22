using AutoMapper;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Eventos.GetEventoByDispositivoId;
public class GetEventoByDispositivoIdValidation : IGetEventoByDispositivoIdValidation
{
    private readonly IEventoRead _repos;
    private readonly IMapper _mapper;

    public GetEventoByDispositivoIdValidation(
        IEventoRead repos,
        IMapper mapper
        )
    {
        _repos = repos;
        _mapper = mapper;
    }

    public async Task<ResponseEvento> Execute(Guid dispositivoId)
    {
        var evento = await _repos.GetByDispositivoId(dispositivoId);
      
         return evento is null ? throw new NotFoundException(ResourceErrorMessages.Evento_Not_Found) : _mapper.Map<ResponseEvento>(evento);
    }
}
