using AutoMapper;
using GestaoDispositivos.App.Validations.Eventos.GetAll;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Services;

namespace GestaoDispositivos.App.Validations.Dispositivos.GetAll;

public class GetAllEventosValidation : IGetAllEventosValidation
{
    private readonly IEventoRead _repo;
    private readonly IMapper _mapper;
    private readonly IClienteLogado _loggedUser;
    public GetAllEventosValidation(
        IEventoRead repo,
        IMapper mapper,
        IClienteLogado loggedUser
        )
    {
        _repo = repo;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseEventos> Execute()
    {
        var result = await _repo.GetEventsByWeek();

        return new ResponseEventos
        {
            Eventos = _mapper.Map<List<ResponseEvento>>(result)
        };
    }
}
