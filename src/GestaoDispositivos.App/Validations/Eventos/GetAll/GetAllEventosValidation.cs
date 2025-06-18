using AutoMapper;
using GestaoDispositivos.App.Validations.Eventos.GetAll;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Services;

namespace GestaoDispositivos.App.Validations.Dispositivos.GetAll;

public class GetAllEventosValidation : IGetAllEventosValidation
{
    private readonly IDispositivoRead _repo;
    private readonly IMapper _mapper;
    private readonly IClienteLogado _loggedUser;
    public GetAllEventosValidation(
        IDispositivoRead repo,
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
        var loggedUser = await _loggedUser.Get();
        var result = await _repo.GetAll(loggedUser);

        return new ResponseEventos
        {
            Eventos = _mapper.Map<List<ResponseEvento>>(result)
        };
    }
}
