using AutoMapper;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Eventos.GetById;
public class GetEventoByIdValidation : IGetEventoByIdValidation
{
    private readonly IEventoRead _repos;
    private readonly IMapper _mapper;

    public GetEventoByIdValidation(
        IEventoRead repos,
        IMapper mapper
        )
    {
        _repos = repos;
        _mapper = mapper;
    }

    public async Task<ResponseEvento> Execute(Guid id)
    {
        var result = await _repos.GetById(id);

        return result is null ? throw new NotFoundException(ResourceErrorMessages.Evento_Not_Found) : _mapper.Map<ResponseEvento>(result);
    }
}
